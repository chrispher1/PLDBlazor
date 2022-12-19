﻿namespace PLD.Blazor.Common
{
    public static class ConstantClass
    {
        public const string SystemUser = "SYSTEM";

        public const string NoRecordFound = "No record found.";
        public const string CarrierCannotAddRecordCodeUsed = "Cannot add a record. Code already used.";
        public const string CarrierCannotUpdateRecordCodeUsed = "Cannot update the record.Code already used.";
        public const string ProductTypeCannotAddRecordCodeUsed = "Cannot add a record. Code already used.";
        public const string ProductTypeCannotUpdateRecordCodeUsed = "Cannot update the record.Code already used.";
        public const string ProductCannotAddRecordCodeUsed = "Cannot add a record. Code already used.";
        public const string ProductCannotUpdateRecordCodeUsed = "Cannot update the record.Code already used.";
        public const string RoleCannotAddRecordNameUsed = "Cannot add a record. Name already used.";
        public const string RoleCannotUpdateRecordNameUsed = "Cannot update the record.Name already used.";
        public const string UserNoRecordFound = @"Username\Password is incorrect.";
        public const string UserCannotAddRecordUserNameUsed = "Cannot register user. User Name already used.";
        public const string ActivityCannotUpdateRecordCodeNotExists = "Cannot update a record. Code not exists.";
        public const string ActivityCannotAddRecordCodeUsed = "Cannot add a record. Code already used.";

        // List of roles
        public const string Role_Commission_User = "Commission_User";
        public const string Role_Commission_User_Read = "Commission_User_Read";
        public const string Role_Commission_User_Edit = "Commission_User_Edit";
        public const string Role_Commission_User_Create = "Commission_User_Create";
        public const string Role_Commission_User_Delete = "Commission_User_Delete";

        public const string Role_Case_User = "Case_User";
        public const string Role_Case_User_Create = "Case_User_Create";
        public const string Role_Case_User_Read = "Case_User_Read";
        public const string Role_Case_User_Edit = "Case_User_Edit";
        public const string Role_Case_User_Delete = "Case_User_Delete";

        public const string Role_Payment_User = "Payment_User";
        public const string Role_Reports_User = "Reports_User";
        public const string Role_Maintenance_User = "Maintenance_User";

        public const string Role_Admin = "Admin";


        // List of Token variables
        public const string Local_Token = "Local Token";
        public const string Local_User = "User";

        // List of Policies
        public const string CaseRolePolicy = "CaseRolePolicy";
        public const string CommissionRolePolicy = "CommissionRolePolicy";
        public const string CommissionUpsertRolePolicy = "CommissionUpsertRolePolicy";
        public const string PaymentRolePolicy = "PaymentRolePolicy";
        public const string ReportRolePolicy = "ReportRolePolicy";
        public const string MaintenanceRolePolicy = "MaintenanceRolePolicy";

        //List of Actions
        public const string EditAction = "Edit";
        public const string AddAction = "Add";
    }
}