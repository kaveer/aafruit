using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class clsEnumsModel
    {
    }

    public enum UserType
    {
        Admin = 1,
        Staff = 2,
        Customer = 3,
        Supplier = 4,
        AdminStaff = 5
    }

    public enum OrderType
    {
        Pending = 1,
        Processing = 2,
        AwaitPayment = 3,
        ReadyForDelivery = 4,
        Delivered = 5,
        Returned = 6,
        Hold = 7
    }

    public enum MeasurementType
    {
        Gram = 1,
        Dekagram = 2,
        Hectogram = 3,
        Kilogram = 4,
        Ton = 5
    }

    public  enum ErrorStatus
    {
        LoginFail = 1,
        LoadCountryMasterDataFail = 2,
        LoadDiscountMasterDataFail = 13,
        LoadFruitMasterDataFail = 14,
        LoadUserTypeMasterDataFail = 15,
        AddUserFail = 16,
        SignUpFail = 3,

        SignupUsernameMissing = 4,
        SigupPasswordMissing = 5,
        SignupPasswordNotMatch = 6,
        SignupNameMissing = 7,
        SignupSurnameMissing = 8,
        SignupCompanyMissing = 9,
        SignupRePasswordMissing = 10,

        InvalidSession = 11,
        UpdateUserDEtailsFail = 12
    }
}
