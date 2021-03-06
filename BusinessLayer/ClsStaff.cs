﻿using BusinessLayer.Helper;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
    public class ClsStaff : clsUser
    {
        clsStaffData dataLayer = new clsStaffData();

        public void AddUser(clsUserDetailsModel item)
        {
            SignUp(item);
        }

        public List<clsFruitModel> ViewInventory()
        {
            return null;
        }

        public void UpsertInventory(StockSummaryModel item)
        {
            if (IsInventoryModelValid(item))
                dataLayer.UpsertInventory(item);
        }

        public List<clsUserDetailsModel> RetrieveUser(UserType userType)
        {
            List<clsUserDetailsModel> result = new List<clsUserDetailsModel>();
            DataSet dataSet = new DataSet();

            dataSet = dataLayer.RetrieveUser(userType);
            if (dataSet?.Tables.Count > 0 && dataSet?.Tables[0]?.Rows.Count > 0)
            {
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    clsUserDetailsModel customer = new clsUserDetailsModel()
                    {
                        iUserDetailsId = Convert.ToInt32(item[0]),
                        iUserId = Convert.ToInt32(item[1]),
                        eUserType = GetUserType(Convert.ToInt32(item[2])),
                        sName = item[3].ToString(),
                        sSurname = item[4].ToString(),
                        sAddress = item[5].ToString(),
                        sEmail = item[6].ToString(),
                        sFixLine = item[7].ToString(),
                        sWebsite = item[8].ToString(),
                        sNote = item[9].ToString(),
                        sCompany = item[10].ToString(),
                        sBRN = item[11].ToString(),
                        iCountryId = Convert.ToInt32(item[12]),
                        sMobile = item[13].ToString(),
                        bStatus = Convert.ToBoolean(item[14]),
                        sFax = item[15].ToString()
                    };

                    result.Add(customer);
                }
            }

            return result;
        }

        public void DeleteCustomer(int userDetailsId)
        {
            dataLayer.DeleteCustomer(userDetailsId);
        }

        public void UpdateOrderStatus(int orderId, OrderType item)
        {
            dataLayer.UpdateOrderStatus(orderId, item);
        }

        public List<clsOrderModel> SalesReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            List<clsOrderModel> result = new List<clsOrderModel>();
            DataSet data = new DataSet();

            data = dataLayer.SalesReport(isSearch, from, to);
            result = BuildSalesReportModel(data);
            return result;
        }

        public List<StockSummaryModel> PurchaseReport(bool isSearch = false, DateTime? from = null, DateTime? to = null)
        {
            List<StockSummaryModel> result = new List<StockSummaryModel>();
            DataSet data = new DataSet();

            data = dataLayer.PurchaseReport(isSearch, from, to);
            result = BuildPurchaseReportModel(data);
            return result;
        }

        private UserType GetUserType(int userTypeId)
        {
            UserType result = new UserType();

            switch (userTypeId)
            {
                case (int)UserType.Admin:
                    result = UserType.Admin;
                    break;
                case (int)UserType.AdminStaff:
                    result = UserType.AdminStaff;
                    break;
                case (int)UserType.Customer:
                    result = UserType.Customer;
                    break;
                case (int)UserType.Staff:
                    result = UserType.Staff;
                    break;
                case (int)UserType.Supplier:
                    result = UserType.Supplier;
                    break;
                default:
                    break;
            }

            return result;
        }

        private bool IsInventoryModelValid(StockSummaryModel item)
        {
            bool result = true;

            if (item.objFruit == null)
                throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidModel));

            if (item.lstStock == null)
                throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidModel));

            if (string.IsNullOrWhiteSpace(item.objFruit.sFruitName))
                throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidFruitName));

            if (item.objFruit.deQuantity == 0)
                throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidQuantity));

            if (item.objFruit.deUnitPrice == 0)
                throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidUnitPrice));


            foreach (var stock in item.lstStock)
            {
                if (stock.objUserDetails == null)
                    throw new FormatException(Convert.ToString((int)ErrorStatus.InventorySupplierDetails));

                if (stock.objUserDetails.iUserDetailsId == 0)
                    throw new FormatException(Convert.ToString((int)ErrorStatus.InventorySupplierDetails));

                if (stock.dDeliveryDate < DateTime.Today)
                    throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidDeliveryDate));

                if (stock.dePurchasePrice == 0)
                    throw new FormatException(Convert.ToString((int)ErrorStatus.InventoryInvalidPurchasePrice));
            }

            return result;
        }

        private List<StockSummaryModel> BuildPurchaseReportModel(DataSet data)
        {
            List<StockSummaryModel> result = new List<StockSummaryModel>();


            if (data?.Tables.Count > 0 || data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    StockSummaryModel stock = new StockSummaryModel()
                    {
                        objFruit = new clsFruitModel()
                        {
                            sFruitName = item[7].ToString()
                        },
                        lstStock = new List<clsStockModel>()
                        {
                            new clsStockModel()
                            {
                                objUserDetails = new clsUserDetailsModel()
                                {
                                    sName = item[0].ToString(),
                                    sUsername = item[1].ToString(),
                                    sCompany = item[2].ToString(),
                                },
                                bStatus = Convert.ToBoolean(item[3].ToString()),
                                dDeliveryDate = Convert.ToDateTime(item[4]),
                                deQuantityAdded = string.IsNullOrWhiteSpace(item[5].ToString())? 0: Convert.ToDecimal(item[5].ToString()),
                                dePurchasePrice = string.IsNullOrWhiteSpace(item[6].ToString())? 0: Convert.ToDecimal(item[6].ToString())
                            }
                        }
                    };

                    result.Add(stock);
                }
            }

            return result;
        }

        private List<clsOrderModel> BuildSalesReportModel(DataSet data)
        {
            List<clsOrderModel> result = new List<clsOrderModel>();

            if (data?.Tables.Count > 0 || data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    clsOrderModel order = new clsOrderModel()
                    {
                        objUserDetails = new clsUserDetailsModel()
                        {
                            sCompany = item[0].ToString()
                        },
                        dRequestedDate = Convert.ToDateTime(item[1]),
                        dDeadline = Convert.ToDateTime(item[2]),
                        deQuantity = Convert.ToDecimal(item[3]),
                        deTotalPrice = Convert.ToDecimal(item[4]),
                        sDiscount = item[5].ToString(),
                        deTotalPriceAfterDiscount = Convert.ToDecimal(item[6]),
                        eOrderType = clsCommon.GetOrderType(Convert.ToInt32(item[7])),
                        objFruit = new clsFruitModel()
                        {
                            sFruitName = item[8].ToString()
                        }
                    };

                    result.Add(order);
                }
            }

            return result;
        }
    }
}
