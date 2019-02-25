using Org.BouncyCastle.Bcpg.OpenPgp;

namespace SpiritWorx.DAL
{
    public class DbConstant
    {

        #region Menu Related Constant
        public class Menu
        {
            public class StoreProcedure
            {
                /*Store Procedure Related to Menu*/
                public const string usp_SelectMenu = "usp_SelectMenu";
                public const string usp_AddUpdateMenu = "usp_AddUpdateMenu";
                public const string usp_DeleteMenu = "usp_DeleteMenu";
                public const string usp_SelectRoleByMenu = "usp_SelectRoleByMenu";
            }

            public class DbColumn
            {
                public const string Id = "Id";
                public const string MenuName = "MenuName";
                public const string DisplayOrder = "DisplayOrder";
                public const string IsActive = "IsActive";
                public const string CreatedDate = "CreatedDate";
            }

            public class DbParameter
            {
                public const string Id = "@Id";
                public const string RoleId = "@RoleId";
                public const string MenuName = "@MenuName";
                public const string DisplayOrder = "@DisplayOrder";
                public const string IsActive = "@IsActive";
                public const string CreatedDate = "@CreatedDate";
            }
        }
        public class DbTypeParameter
        {
            public const string CountryTableType = "@CountryTableType";
            public const string EntityIdIntTableType = "@EntityIdIntTableType";
            public const string PropertiePackagingTableType = "@PropertiePackagingTableType";
            public const string TargetMarketTableType = "@TargetMarketTableType";
            public const string FacilitiesProcessTableType = "@FacilitiesProcessTableType";
            public const string IdIntEntityIdIntTableType = "@IdIntEntityIdIntTableType";
            public const string MonthlyPricingTableType = "@MonthlyPricingTableType";
            public const string CapacityTableType = "@CapacityTableType";
            public const string USTotalTableType = "@USTotalTableType";
            public const string MenuPermissionTableType = "@MenuPermissionTableType";
            public const string FacilityProcessLineNumber = "@FacilityProcessLineNumber";

            public const string ProcessTableType = "@ProcessTableType";
            public const string SubProcessTableType = "@SubProcessTableType";
            public const string PolymersUsedTableType = "@PolymersUsedTableType";
            public const string StructureTableType = "@StructureTableType";
            public const string CompanyRevenueTableType = "@CompanyRevenueTableType";
        }
       
        public class DbParameters
        {
            public const string StartPage = "@StartPage";
            public const string PageLength = "@PageLength";
            public const string NoOfPages = "@NoOfPages";
            public const string TotalRecords = "@TotalRecords";
            public const string SearchKeyword = "@SearchKeyword";
            public const string StartDate = "@StartDate";
            public const string EndDate = "@EndDate";
            public const string EntityType = "@EntityType";
            public const string IsDeleted = "@IsDeleted";

        }
        public class DbTypeName
        {
            public const string CountryTableType = "CountryTableType";
            public const string EntityIdIntTableType = "EntityIdIntTableType";
            public const string IdIntEntityIdIntTableType = "IdIntEntityIdIntTableType";
            public const string MonthlyPricingTableType = "@MonthlyPricingTableType";
            public const string FacilitiesProcessTableType = "FacilitiesProcessTableType";
            public const string PropertiePackagingTableType = "PropertiePackagingTableType";
            public const string TargetMarketTableType = "TargetMarketTableType";
            public const string MenuPermissionTableType = "MenuPermissionTableType";
            public const string FacilityProcessLineNumber = "FacilityProcessLineNumber";
            public const string ProcessTableType = "ProcessTableType";
            public const string SubProcessTableType = "SubProcessTableType";
            public const string PolymersUsedTableType = "PolymersUsedTableType";
            public const string StructureTableType = "StructureTableType";
            public const string CompanyRevenueTableType = "CompanyRevenueTableType";

        }
        #endregion
        #region Role Related Constant

        public class Role
        {
            public class StoreProcedure
            {
                /*Store Procedure Related to Role*/
                public const string usp_AddUpdateUserRole = "usp_AddUpdateUserRole";
                public const string usp_SelectUserRole = "usp_SelectUserRole";
                public const string usp_SelectMenuOrSubMenu = "usp_SelectMenuOrSubMenu";
                public const string usp_SelectPermission = "usp_SelectPermission";
                public const string usp_AddUpdatePermission = "usp_AddUpdatePermission";
                public const string usp_DeleteRole = "usp_DeleteRole";

            }

            public class DbColumn
            {
                public const string Id = "Id";
                public const string RoleId = "RoleId";
                public const string MenuId = "MenuId";
                public const string SubMenuId = "SubMenuId";
                public const string SubMenuName = "SubMenuName";
                public const string MenuName = "MenuName";
                public const string RoleName = "RoleName";
                public const string IsActive = "IsActive";
                public const string CreatedDate = "CreatedDate";
            }

            public class DbParameter
            {
                public const string Id = "Id";
                public const string RoleName = "@RoleName";
                public const string IsActive = "@IsActive";
                public const string CreatedDate = "@CreatedDate";
            }
        }
        #endregion
        #region SubMenu Related Constant

        public class SubMenu
        {
            public class StoreProcedure
            {
                /*Store Procedure Related to Menu*/
                public const string usp_SelectSubMenu = "usp_SelectSubMenu";
                public const string usp_AddUpdateSubMenu = "usp_AddUpdateSubMenu";
                public const string usp_DeleteSubMenu = "usp_DeleteSubMenu";
                public const string usp_SelectSubMenuByRole = "usp_SelectSubMenuByRole";
            }

            public class DbColumn
            {
                public const string Id = "Id";
                public const string MenuName = "MenuName";
                public const string MenuLink = "MenuLink";
                public const string SubMenuName = "SubMenuName";
                public const string MenuId = "MenuId";
                public const string DisplayOrder = "DisplayOrder";
                public const string IsActive = "IsActive";
                public const string CreatedDate = "CreatedDate";
                public const string ListPageHeading = "ListPageHeading";
                public const string ListPageDescription = "ListPageDescription";
                public const string AddPageHeading = "AddPageHeading";
                public const string AddPageDescription = "AddPageDescription";
                public const string IsAddPage = "IsAddPage";
            }

            public class DbParameter
            {
                public const string Id = "Id";
                public const string SubMenuName = "@SubMenuName";
                public const string MenuLink = "@MenuLink";
                public const string MenuId = "@MenuId";
                public const string DisplayOrder = "@DisplayOrder";
                public const string IsActive = "@IsActive";
                public const string CreatedDate = "@CreatedDate";
                public const string ListPageHeading = "@ListPageHeading";
                public const string ListPageDescription = "@ListPageDescription";
                public const string AddPageHeading = "@AddPageHeading";
                public const string AddPageDescription = "@AddPageDescription";
                public const string IsAddPage = "@IsAddPage";

            }
        }
        #endregion
        public const string ConnectionString = "SpiritWorxConnectionString";
        public const string IsdlConnectionString = "SpiritWroxISDLConnectionString";
        public const string DatabaseObjectOwner = "dbo";
        public const string EntityIdIntTableType = "EntityIdIntTableType";
        public const string LineItemTableType = "LineItemTableType";
        public const string IdIntEntityIdIntTableType = "IdIntEntityIdIntTableType";
        public const string IdIntBitTableType = "IdIntBitTableType";
        public const string IdIntTinyIntTableType = "IdIntTinyIntTableType";
        public const string EntityColorTableType = "EntityColorTableType";
        public const string GarmentSizeTableType = "GarmentSizeTableType";
        public const string OrderDesignTextTableType = "OrderDesignTextTableType";
        public const string DesignTextTableType = "DesignTextTableType";
        public const string DesignPlacementTableType = "DesignPlacementTableType";
        public const string GarmentPriceTableType = "GarmentPriceTableType";
        public const string OrderDesignQuantityTableType = "OrderDesignQuantityTableType";
        public const string GarmentTypeDesignCategoryTableType = "GarmentTypeDesignCategoryTableType";
        public const string DecorationTypeXGarmentTableType = "DecorationTypeXGarmentTableType";
        public const string DesignInkColorTableType = "DesignInkColorTableType";
        public const string EntityDesignInkColorTableType = "EntityDesignInkColorTableType";
        public const string OrderDesignInkColorTableType = "OrderDesignInkColorTableType";
        public const string ProductionTimeXGarmentTableType = "ProductionTimeXGarmentTableType";
        public const string IdIntStatusBitTableType = "IdIntStatusBitTableType";
        public const string OrderPrintPersonalizationTableType = "OrderPrintPersonalizationTableType";
        public const string RelatedGarmentTableType = "RelatedGarmentTableType";
        public const string EntityIdInIdTextTableType = "EntityIdInIdTextTableType";
        public const string GarmentColorTableType = "GarmentColorTableType";
        public const string OrderArtWorkTableType = "OrderArtWorkTableType";
        public const string GarmentSizeGroupTableType = "GarmentSizeGroupTableType";
        public const string FreeOrderGarmentSizeTableType = "FreeOrderGarmentSizeTableType";
        public const string FreeOrderGarmentTableType = "FreeOrderGarmentTableType";
        public const string ErrorConnection = "Error:Connection String Not Exists";
        public const string StoreGarmentImagesTableType = "StoreGarmentImagesTableType";
        public const string StoreGradeLevelTableType = "StoreGradeLevelTableType";
        public const string StudentOrderGarmentTableType = "StudentOrderGarmentTableType";
        public const string StudentOrderPaymentTableType = "StudentOrderPaymentTableType";
        public const string StoreSelectedGradeTableType = "StoreSelectedGradeTableType";
        public const string StoreTeacherTableType = "StoreTeacherTableType";
        public const string StoreGarmentColorTableType = "StoreGarmentColorTableType";
        public const string StoreGradeColorTableType = "StoreGradeColorTableType";
        public const string DiscountOrderTableType = "DiscountOrderTableType";
        public const string DiscountGiftGarmentTableType = "DiscountGiftGarmentTableType";
        public const string OrderFreeGiftGarmentSizeTableType = "OrderFreeGiftGarmentSizeTableType";
        public const string PrintColorTableType = "PrintColorTableType";


        public class StoreProcedure
        {
            /*Store Procedure Related to User*/
            public const string usp_AddUpdateUser = "usp_AddUpdateUser";
            public const string usp_GetUser = "usp_GetUser";
            public const string usp_GetUsersPaged = "usp_GetUsersPaged";
            public const string usp_ChangePassword = "usp_ChangePassword";
            public const string usp_DeleteUser = "usp_DeleteUser";
            public const string usp_CheckUserEmailAvailability = "usp_CheckUserEmailAvailability";
            public const string usp_UpdateOrderArtWorkDetail = "usp_UpdateOrderArtWorkDetail";
            public const string usp_DeleteUserImage = "usp_DeleteUserImage";
            public const string usp_GetFinancialStatement = "usp_GetFinancialStatement";

            /*Store Procedure Related to Order ArtWork*/
            public const string usp_AddUpdateOrderArtWork = "usp_AddUpdateOrderArtWork";
            public const string usp_SelectOrderArtWork = "usp_SelectOrderArtWork";
            public const string usp_SelectOrderArtWorks = "usp_SelectOrderArtWorks";
            public const string usp_SelectOrderArtWorkHistories = "usp_SelectOrderArtWorkHistories";
            public const string usp_ApproveOrderArtWork = "usp_ApproveOrderArtWork";
            public const string usp_SelectApprovedArtWork = "usp_SelectApprovedArtWork";
            public const string usp_DeleteOrderArtWorks = "usp_DeleteOrderArtWorks";
            public const string usp_CheckOrderArtWorkNoAvailability = "usp_CheckOrderArtWorkNoAvailability";
            public const string usp_GetNoOfUploadedArtWork = "usp_GetNoOfUploadedArtWork";
            public const string usp_GetOrdersForReminderEmail = "usp_GetOrdersForReminderEmail";
            public const string usp_SelectLatestOrderConversation = "usp_SelectLatestOrderConversation";
            public const string usp_DeleteUnapprovedArtworkORInvoice = "usp_DeleteUnapprovedArtworkORInvoice";
            public const string usp_GetLatestOrderArtwork = "usp_GetLatestOrderArtwork";
            public const string usp_SelectStoreGarmentColorsWithSorting = "usp_SelectStoreGarmentColorsWithSorting";
            public const string usp_RetireUnRetireDesign = "usp_RetireUnRetireDesign";


            /*Store Procedure Related to EntityAttachment*/
            public const string usp_DeleteEntityAttachments = "usp_DeleteEntityAttachments";
            public const string usp_AddUpdateEntityAttachments = "usp_AddUpdateEntityAttachments";
            public const string usp_UpdateEntityIDEntityAttachments = "usp_UpdateEntityIDEntityAttachments";
            public const string usp_UpdateEntityIDWithUrlEntityAttachments = "usp_UpdateEntityIDWithUrlEntityAttachments";
            public const string usp_GetEntityAttachments = "usp_GetEntityAttachments";
            public const string usp_GetApprovedArtWorkFiles = "usp_GetApprovedArtWorkFiles";
            public const string usp_SelectDirtyFiles = "usp_SelectDirtyFiles";

            /*Store Procedure Related to InkColor*/
            public const string usp_AddUpdateInkColor = "usp_AddUpdateInkColor";
            public const string usp_AddUpdateColorVariation = "usp_AddUpdateColorVariation";
            public const string usp_GetInkColor = "usp_GetInkColor";
            public const string usp_GetInkColors = "usp_GetInkColor";
            public const string usp_GetGarmentInkColors = "usp_GetGarmentInkColors";
            public const string usp_DeleteInkColor = "usp_DeleteInkColor";

            /*Store Procedure Related to Size*/
            public const string usp_AddUpdateSize = "usp_AddUpdateSize";
            public const string usp_GetSize = "usp_GetSize";
            public const string usp_GetSizes = "usp_GetSize";
            public const string usp_GetSizesAditionalPrices = "usp_GetSizesAditionalPrices";
            public const string usp_DeleteSize = "usp_DeleteSize";

            /*Store Procedure Related to Broucher*/
            public const string usp_AddUpdateBroucher = "usp_AddUpdateBroucher";
            public const string usp_SelectBroucher = "usp_SelectBroucher";
            public const string usp_SelectBrouchers = "usp_SelectBrouchers";
            public const string usp_DeleteBroucher = "usp_DeleteBroucher";
            public const string usp_UpdateBroucherSortOrder = "usp_UpdateBroucherSortOrder";

            /*Store Procedure Related to GarmentType*/
            public const string usp_GetGarmentType = "usp_GetGarmentType";
            public const string usp_GetGarmentTypes = "usp_GetGarmentTypes";
            public const string usp_GetParentAndChildGarmentTypes = "usp_GetParentAndChildGarmentTypes";
            public const string usp_GetAllGarmentTypes = "usp_GetAllGarmentTypes";
            public const string usp_DeleteGarmentType = "usp_DeleteGarmentType";
            public const string usp_AddUpdateGarmentType = "usp_AddUpdateGarmentType";
            public const string usp_UpdateGarmentTypesSortOrder = "usp_UpdateGarmentTypesSortOrder";

            /*Store Procedure Related to Entity Color*/
            public const string usp_GetEntityColors = "usp_GetEntityColors";
            public const string usp_GetAllEntityColors = "usp_GetAllEntityColors";
            public const string usp_GetEntityColorSizes = "usp_GetEntityColorSizes";
            public const string usp_DeleteEntityColor = "usp_DeleteEntityColor";
            public const string usp_AddUpdateEntityColor = "usp_AddUpdateEntityColor";
            public const string usp_GetEntityTypeSizes = "usp_GetEntityTypeSizes";
            public const string usp_SelectGarementSizes = "usp_SelectGarementSizes";

            /*Store Procedure Related to Garment Size*/
            public const string usp_GetGarmentSizes = "usp_GetGarmentSizes";
            public const string usp_DeleteGarmentSize = "usp_DeleteGarmentSize";
            public const string usp_AddUpdateGarmentSize = "usp_AddUpdateGarmentSize";
            public const string usp_UpdateSizeSortOrder = "usp_UpdateSizeSortOrder";
            public const string usp_SelectGarmentSizesWithAllSizes = "usp_SelectGarmentSizesWithAllSizes";

            /*Store Procedure Related to Design Text*/
            public const string usp_GetDesignTexts = "usp_GetDesignTexts";
            public const string usp_DeleteDesignText = "usp_DeleteDesignText";
            public const string usp_AddUpdateDesignText = "usp_AddUpdateDesignText";

            /*Store Procedure Related to Design Ink Color*/
            public const string usp_GetDesignInkColors = "usp_GetDesignInkColors";
            public const string usp_DeleteDesignInkColor = "usp_DeleteDesignInkColor";
            public const string usp_AddUpdateDesignInkColor = "usp_AddUpdateDesignInkColor";

            /*Store Procedure Related to Design Category*/
            public const string usp_GetDesignCategories = "usp_GetDesignCategories";
            public const string usp_GetAllDesignCategories = "usp_GetAllDesignCategories";
            public const string usp_GetBackDesignCategories = "usp_GetBackDesignCategories";
            public const string usp_DeleteDesignCategory = "usp_DeleteDesignCategory";
            public const string usp_UpdateDesignCategoriesSortOrder = "usp_UpdateDesignCategoriesSortOrder";
            public const string usp_GetDesignCategory = "usp_GetDesignCategory";
            public const string usp_AddUpdateDesignCategory = "usp_AddUpdateDesignCategory";
            public const string usp_AddUpdateDesignCategoryXGarmentType = "usp_AddUpdateDesignCategoryXGarmentType";
            public const string usp_GetGarmentDesignCategories = "usp_GetGarmentDesignCategories";
            public const string usp_UpdateInkColorSortOrder = "usp_UpdateInkColorSortOrder";

            /*Store Procedure Related to Design*/
            public const string usp_GetDesigns = "usp_GetDesigns";
            public const string usp_GetDesignsPaged = "usp_GetDesignsPaged";
            public const string usp_DeleteDesign = "usp_DeleteDesign";
            public const string usp_GetDesign = "usp_GetDesign";
            public const string usp_AddUpdateDesign = "usp_AddUpdateDesign";
            public const string usp_GetFeaturedDesigns = "usp_GetFeaturedDesigns";
            public const string usp_GetSeachDesignsResult = "usp_GetSeachDesignsResult";
            public const string usp_UpdateDesignSortOrder = "usp_UpdateDesignSortOrder";

            /*Store Procedure Related to Placement*/
            public const string usp_AddUpdatePlacement = "usp_AddUpdatePlacement";
            public const string usp_GetPlacement = "usp_GetPlacement";
            public const string usp_GetPlacements = "usp_GetPlacement";
            public const string usp_DeletePlacement = "usp_DeletePlacement";

            /*Store Procedure Related to Design Placement*/
            public const string usp_AddUpdateDesignPlacement = "usp_AddUpdateDesignPlacement";
            public const string usp_GetDesignPlacement = "usp_GetDesignPlacement";
            public const string usp_GetDesignPlacements = "usp_GetDesignPlacements";
            public const string usp_DeleteDesignPlacement = "usp_DeleteDesignPlacement";

            /*Store Procedure Related to Mascot*/
            public const string usp_AddUpdateMascot = "usp_AddUpdateMascot";
            public const string usp_GetMascot = "usp_GetMascot";
            public const string usp_GetMascots = "usp_GetMascot";
            public const string usp_DeleteMascot = "usp_DeleteMascot";

            /*Store Procedure Related to CmsPage*/
            public const string usp_AddUpdateCmsPage = "usp_AddUpdateCmsPage";
            public const string usp_GetCmsPage = "usp_GetCmsPage";
            public const string usp_GetCmsPagesPaged = "usp_GetCmsPagesPaged";
            public const string usp_DeleteCmsPage = "usp_DeleteCmsPage";

            /*Store Procedure Related to Testimonial*/
            public const string usp_AddUpdateTestimonial = "usp_AddUpdateTestimonial";
            public const string usp_GetTestimonial = "usp_GetTestimonial";
            public const string usp_GetTestimonials = "usp_GetTestimonials";
            public const string usp_DeleteTestimonial = "usp_DeleteTestimonial";
            public const string usp_UpdateTestimonialStatus = "usp_UpdateTestimonialStatus";
            public const string usp_GetNewUnApprovedTestimonialCount = "usp_GetNewUnApprovedTestimonialCount";

            /*Store Procedure Related to Garment*/
            public const string usp_GetGarment = "usp_GetGarment";
            public const string usp_GetGarmentsPaged = "usp_GetGarmentsPaged";
            public const string usp_SelectGarments = "usp_SelectGarments";
            public const string usp_GetFeaturedGarments = "usp_GetFeaturedGarments";
            public const string usp_GetGarmentsSearchResult = "usp_GetGarmentsSearchResult";
            public const string usp_DeleteGarment = "usp_DeleteGarment";
            public const string usp_AddUpdateGarment = "usp_AddUpdateGarment";
            public const string usp_GetGarmentsByDesignId = "usp_GetGarmentsByDesignId";
            public const string usp_UpdateGarmentSortOrder = "usp_UpdateGarmentSortOrder";
            public const string usp_AddUpdateRelatedGarment = "usp_AddUpdateRelatedGarment";
            public const string usp_DeleteRelatedGarment = "usp_DeleteRelatedGarment";
            public const string usp_GetRelatedGarments = "usp_GetRelatedGarments";
            public const string usp_AddUpdateGarmentSizeGroup = "usp_AddUpdateGarmentSizeGroup";
            public const string usp_SelectGarmentSizeGroups = "usp_SelectGarmentSizeGroups";
            public const string usp_GetStoreSettings = "usp_GetStoreSettings";


            /*Store Procedure Related to Garment Price*/
            public const string usp_AddUpdateGarmentPrice = "usp_AddUpdateGarmentPrice";
            public const string usp_GetGarmentPrices = "usp_GetGarmentPrices";
            public const string usp_GetGarmentPrice = "usp_GetGarmentPrice";
            public const string usp_DeleteGarmentPrice = "usp_DeleteGarmentPrice";
            public const string usp_GetGarmentPricesWithDecorationTypes = "usp_GetGarmentPricesWithDecorationTypes";

            /*Store Procedure Related to Quantity*/
            public const string usp_GetQuantity = "usp_GetQuantity";
            public const string usp_GetQuantities = "usp_GetQuantities";
            public const string usp_DeleteQuantity = "usp_DeleteQuantity";
            public const string usp_AddUpdateQuantityMaster = "usp_AddUpdateQuantityMaster";
            public const string usp_GetItemQuantitiesRange = "usp_GetItemQuantitiesRange";

            /*Store Procedure Related to Order*/
            public const string usp_AddUpdateOrderTemplate = "usp_AddUpdateOrderTemplate";
            public const string usp_AddUpdateOrderLineItem = "usp_AddUpdateOrderLineItem";
            public const string usp_GetOrderTemplate = "usp_GetOrderTemplate";
            public const string usp_GetOrderTemplateDetails = "usp_GetOrderTemplateDetails";
            public const string usp_SelectOrderTemplatesPaged = "usp_SelectOrderTemplatesPaged";
            public const string usp_GetOrderDetailsPaged = "usp_GetOrderDetailsPaged";
            public const string usp_GetOrderLineItems = "usp_GetOrderLineItems";
            public const string usp_GetAssociateOrderLineItems = "usp_GetAssociateOrderLineItems";
            public const string usp_GetCartOrderLineItems = "usp_GetCartOrderLineItems";
            public const string usp_GetOrderLineItem = "usp_GetOrderLineItem";
            public const string usp_GetOrderDesignQuantities = "usp_GetOrderDesignQuantities";
            public const string usp_GetOrderLineItemHeader = "usp_GetOrderLineItemHeader";
            public const string usp_AddUpdateOrderDesignText = "usp_AddUpdateOrderDesignText";
            public const string usp_GetOrderDesignText = "usp_GetOrderDesignText";
            public const string usp_AddUpdateOrderDesignQuantity = "usp_AddUpdateOrderDesignQuantity";

            public const string usp_SelectFreeOrderGarments = "usp_SelectFreeOrderGarments";
            public const string usp_SelectFreeOrderGarmentSizes = "usp_SelectFreeOrderGarmentSizes";
            public const string usp_AddUpdateFreeOrderGarmentSize = "usp_AddUpdateFreeOrderGarmentSize";
            public const string usp_AddUpdateFreeOrderGarment = "usp_AddUpdateFreeOrderGarment";
            public const string usp_AddUpdateFreeOrderGarmentForStore = "usp_AddUpdateFreeOrderGarmentForStore";

            public const string usp_AddUpdateFreeOrderGarments = "usp_AddUpdateFreeOrderGarments";
            public const string usp_SelectDiscountedGarmentIdsFromOrder = "usp_SelectDiscountedGarmentIdsFromOrder";

            public const string usp_AddUpdateOrderAddress = "usp_AddUpdateOrderAddress";
            public const string usp_GetOrderAddresses = "usp_GetOrderAddresses";
            public const string usp_GetOrderDesignInkColors = "usp_GetOrderDesignInkColors";
            public const string usp_AddUpdateOrderDesignInkColor = "usp_AddUpdateOrderDesignInkColor";
            public const string usp_DeleteOrderLineItem = "usp_DeleteOrderLineItem";
            public const string usp_UpdateOrderLineItems = "usp_UpdateOrderLineItems";
            public const string usp_DeleteOrder = "usp_DeleteOrder";
            public const string usp_GetSizesForPrintPersonalization = "usp_GetSizesForPrintPersonalization";
            public const string usp_GetPrintPersonalizationDetails = "usp_GetPrintPersonalizationDetails";
            public const string usp_AddUpdateOrderPrintPersonalization = "usp_AddUpdateOrderPrintPersonalization";
            public const string usp_AddUpdateOrderProgress = "usp_AddUpdateOrderProgress";
            public const string usp_GetOrderProgresses = "usp_GetOrderProgresses";
            public const string usp_AddUpdateAddress = "usp_AddUpdateAddress";
            public const string usp_GetAddresses = "usp_GetAddresses";
            public const string usp_GetOrderDetailList = "usp_GetOrderDetailList";
            public const string usp_GetOrderDetails = "usp_GetOrderDetails";
            public const string usp_CheckOrderNumberAvailability = "usp_CheckOrderNumberAvailability";
            public const string usp_GetOrderCount = "usp_GetOrderCount";
            public const string usp_AddUpdateOrderInvoice = "usp_AddUpdateOrderInvoice";
            public const string usp_UpdateOrderInvoiceStatus = "usp_UpdateOrderInvoiceStatus";
            public const string usp_GetLatestOrderInvoice = "usp_GetLatestOrderInvoice";
            public const string usp_GetOrderInvoice = "usp_GetOrderInvoice";
            public const string usp_GetInvoiceDetail = "usp_GetInvoiceDetail";
            public const string usp_SelectOrderInvoiceDetail = "usp_SelectOrderInvoiceDetail";
            public const string usp_SelectOrderInvoiceHistories = "usp_SelectOrderInvoiceHistories";
            public const string usp_SelectOrderInvoices = "usp_SelectOrderInvoices";
            public const string usp_UpdateOrderStatusShipedToComplete = "usp_UpdateOrderStatusShipedToComplete";
            public const string usp_SelectOrderInvoiceCount = "usp_SelectOrderInvoiceCount";
            public const string usp_UpdateOrderLineItem = "usp_UpdateOrderLineItem";
            public const string usp_UpdateOrderLineItemsByParentLineItem = "usp_UpdateOrderLineItemsByParentLineItem";
            public const string usp_DeleteOrderProgress = "usp_DeleteOrderProgress";
            public const string usp_UpdateOrderArtworkOrInvoiceStatus = "usp_UpdateOrderArtworkOrInvoiceStatus";
            public const string usp_UpdatePurchaseOrder = "usp_UpdatePurchaseOrder";
            public const string usp_UpdateOrderPaymentStatus = "usp_UpdateOrderPaymentStatus";
            public const string usp_UpdateFinancialStatement = "usp_UpdateFinancialStatement";
            public const string usp_GetStoreGarmentList = "usp_GetStoreGarmentList";





            /*Store Procedure Related to DecorationType*/
            public const string usp_AddUpdateDecorationType = "usp_AddUpdateDecorationType";
            public const string usp_GetDecorationTypes = "usp_GetDecorationTypes";
            public const string usp_DeleteDecorationType = "usp_DeleteDecorationType";
            public const string usp_GetGarmentDecorationTypes = "usp_GetGarmentDecorationTypes";
            public const string usp_AddUpdateDecorationTypeXGarment = "usp_AddUpdateDecorationTypeXGarment";
            public const string usp_GetDecorationTypeXGarments = "usp_GetDecorationTypeXGarments";


            /*Store Procedure Related to Discount*/
            public const string usp_AddUpdateDiscount = "usp_AddUpdateDiscount";
            public const string usp_GetDiscount = "usp_GetDiscount";
            public const string usp_GetDiscountsPaged = "usp_GetDiscountsPaged";
            public const string usp_DeleteDiscount = "usp_DeleteDiscount";
            public const string usp_CheckPromoCodeAvailability = "usp_CheckPromoCodeAvailability";
            public const string usp_GetPromoCode = "usp_GetPromoCode";
            public const string usp_CheckDiscountAccountCategoryAvailability = "usp_CheckDiscountAccountCategoryAvailability";

            public const string usp_GetDesignProofs = "usp_GetDesignProofs";
            public const string usp_GetDesignProofDetail = "usp_GetDesignProofDetail";
            public const string usp_AddUpdateDesignProof = "usp_AddUpdateDesignProof";
            public const string usp_DeleteDesignProof = "usp_DeleteDesignProof";


            public const string usp_GetEntityDesignInkColors = "usp_GetEntityDesignInkColors";
            public const string usp_AddUpdateEntityDesignInkColor = "usp_AddUpdateEntityDesignInkColor";
            public const string usp_DeleteEntityDesignInkColor = "usp_DeleteEntityDesignInkColor";

            public const string usp_DeleteProductionTime = "usp_DeleteProductionTime";
            public const string usp_GetGarmentProductionTimes = "usp_GetGarmentProductionTimes";
            public const string usp_GetMaxGarmentProductionTimes = "usp_GetMaxGarmentProductionTimes";
            public const string SelectAllGarmentProductionTimes = "SelectAllGarmentProductionTimes";
            public const string usp_GetProductionTime = "usp_GetProductionTime";
            public const string usp_AddUpdateProductionTime = "usp_AddUpdateProductionTime";
            public const string usp_AddUpdateProductionTimeXGarment = "usp_AddUpdateProductionTimeXGarment";
            public const string usp_AddUpdateDiscountOrder = "usp_AddUpdateDiscountOrder";
            public const string usp_SelectDiscountOrder = "usp_SelectDiscountOrder";
            public const string usp_AddUpdateDiscountGiftGarment = "usp_AddUpdateDiscountGiftGarment";
            public const string usp_SelectDiscountGiftGarment = "usp_SelectDiscountGiftGarment";
            public const string usp_AddUpdateAdvancePromoCode = "usp_AddUpdateAdvancePromoCode";
            public const string usp_GetAdvancePromoCodePaged = "usp_GetAdvancePromoCodePaged";



            /*Store Procedure Related to GarmentSaleType*/
            public const string usp_AddUpdateGarmentSaleType = "usp_AddUpdateGarmentSaleType";
            public const string usp_GetGarmentSaleType = "usp_GetGarmentSaleType";
            public const string usp_DeleteGarmentSaleType = "usp_DeleteGarmentSaleType";

            /*Store Procedure Related to Resources */
            public const string usp_AddUpdateResource = "usp_AddUpdateResource";
            public const string usp_GetResource = "usp_GetResource";
            public const string usp_GetResourcesBySearchKeyword = "usp_GetResourcesBySearchKeyword";
            public const string usp_GetResourcesPaged = "usp_GetResourcesPaged";
            public const string usp_CheckResourceKeyAvailability = "usp_CheckResourceKeyAvailability";

            /*Store Procedure Related to Conversation */
            public const string usp_AddUpdateConversation = "usp_AddUpdateConversation";
            public const string usp_GetConversations = "usp_GetConversations";
            public const string usp_GetConversation = "usp_GetConversation";
            public const string usp_SelectLastestConversation = "usp_SelectLastestConversation";
            public const string usp_SetConversationAsRead = "usp_SetConversationAsRead";
            public const string usp_GetUnreadMessageCount = "usp_GetUnreadMessageCount";
            public const string usp_SelectUnreadMessageCount = "usp_SelectUnreadMessageCount";

            /*Store Procedure Related to TroubleTicket*/
            public const string usp_AddUpdateTroubleTicket = "usp_AddUpdateTroubleTicket";
            public const string usp_AddUpdateProblemCategory = "usp_AddUpdateProblemCategory";
            public const string usp_GetProblemCategories = "usp_GetProblemCategories";
            public const string usp_GetProblemCategory = "usp_GetProblemCategory";
            public const string usp_GetTroubleTicketDetail = "usp_GetTroubleTicketDetail";
            public const string usp_GetTroubleTicketsPaged = "usp_GetTroubleTicketsPaged";
            public const string usp_GetTroubleTicketCount = "usp_GetTroubleTicketCount";

            /*Store Procedure Related to Brand*/
            public const string usp_AddUpdateBrand = "usp_AddUpdateBrand";
            public const string usp_DeleteBrand = "usp_DeleteBrand";
            public const string usp_GetBrandsPaged = "usp_GetBrandsPaged";
            public const string usp_GetBrand = "usp_GetBrand";
            public const string usp_AddUpdateGarmentCategory = "usp_AddUpdateGarmentCategory";
            public const string usp_GetGarmentCategory = "usp_GetGarmentCategory";
            public const string usp_GetAllGarmentCategories = "usp_GetAllGarmentCategories";
            public const string usp_GetGarmentCategories = "usp_GetGarmentCategories";
            public const string usp_UpdateGarmentCategoriesSortOrder = "usp_UpdateGarmentCategoriesSortOrder";
            public const string usp_DeleteGarmentCategory = "usp_DeleteGarmentCategory";
            public const string usp_GetGarmentsListCategoryWisePaged = "usp_GetGarmentsListCategoryWisePaged";
            public const string usp_GetGarmentsListCategoryWise = "usp_GetGarmentsListCategoryWise";
            public const string usp_GetGarmentsFilteredListCategoryWise = "usp_GetGarmentsFilteredListCategoryWise";
            public const string usp_AddUpdateBrandColor = "usp_AddUpdateBrandColor";
            public const string usp_SelectBrandColor = "usp_SelectBrandColor";
            public const string usp_SelectBrandColors = "usp_SelectBrandColors";
            public const string usp_SelectBrandColorsPaged = "usp_SelectBrandColorsPaged";
            public const string usp_DeleteBrandColor = "usp_DeleteBrandColor";
            public const string usp_AddUpdateGarmentColor = "usp_AddUpdateGarmentColor";
            public const string usp_SelectGarmentColorsWithGarmentFrontImage = "usp_SelectGarmentColorsWithGarmentFrontImage";
            public const string usp_SelectAllGarmentColorsWithGarmentFrontImage = "usp_SelectAllGarmentColorsWithGarmentFrontImage";
            public const string usp_SelectGarmentColors = "usp_SelectGarmentColors";
            public const string usp_SelectGarmentColorsHavingSizes = "usp_SelectGarmentColorsHavingSizes";
            public const string usp_SelectGarmentColorsWithSizes = "usp_SelectGarmentColorsWithSizes";

            public const string usp_SelectGarmentBrandColors = "usp_SelectGarmentBrandColors";
            public const string usp_AddUpdateGarmentColorImage = "usp_AddUpdateGarmentColorImage";
            public const string usp_SelectGarmentColorImage = "usp_SelectGarmentColorImage";
            public const string usp_SelectGarmentColorImageByGarmentAndColorId = "usp_SelectGarmentColorImageByGarmentAndColorId";
            public const string usp_DeleteGarmentColorAndSizeAndImages = "usp_DeleteGarmentColorAndSizeAndImages";

            public const string usp_SelectGarmentBrandsByGarmentType = "usp_SelectGarmentBrandsByGarmentType";
            public const string usp_SelectGarmentColorsByGarmentType = "usp_SelectGarmentColorsByGarmentType";
            public const string usp_district = "usp_district";


            /*Store Procedure Related to Store*/
            public const string usp_AddUpdateStoreDetail = "usp_AddUpdateStoreDetail";
            public const string usp_AddUpdateStoreDesign = "usp_AddUpdateStoreDesign";
            public const string usp_AddUpdateStoreGarment = "usp_AddUpdateStoreGarment";
            public const string usp_AddUpdateStoreGarmentColor = "usp_AddUpdateStoreGarmentColor";
            public const string usp_AddUpdateStoreGarmentImages = "usp_AddUpdateStoreGarmentImages";
            public const string usp_AddUpdateStoreOrder = "usp_AddUpdateStoreOrder";
            public const string usp_AddUpdateStoreOrderItemDetail = "usp_AddUpdateStoreOrderItemDetail";
            public const string usp_AddUpdateStoreUserDetail = "usp_AddUpdateStoreUserDetail";
            public const string usp_UpdateStoreDesignSendEmail = "usp_UpdateStoreDesignSendEmail";
            public const string usp_MergeStoreDetail = "usp_MergeStoreDetail";
            public const string usp_UpdateStoreStatus = "usp_UpdateStoreStatus";
            public const string usp_UpdateStoreReviewStatus = "usp_UpdateStoreReviewStatus";
            public const string usp_UpdateStoreTax = "usp_UpdateStoreTax";
            public const string usp_AddStoreContactForm = "usp_AddStoreContactForm";


            public const string usp_SelectStoreDetail = "usp_SelectStoreDetail";
            public const string usp_SelectStoreDetails = "usp_SelectStoreDetails";
            public const string usp_SelectStoreDetailPaged = "usp_SelectStoreDetailPaged";
            public const string usp_SelectClosedStores = "usp_SelectClosedStores";
            public const string usp_DeleteStoreDetail = "usp_DeleteStoreDetail";
            public const string usp_SelectStoreUserDetail = "usp_SelectStoreUserDetail";
            public const string usp_SelectStoreUserDetailPaged = "usp_SelectStoreUserDetailPaged";
            public const string usp_DeleteStoreUser = "usp_DeleteStoreUser";
            public const string usp_SelectStoreOrdersPaged = "usp_SelectStoreOrdersPaged";
            public const string usp_SelectStoreOrdersList = "usp_SelectStoreOrdersList";

            public const string usp_SelectStoreOrdersPagedWithSortOrder = "usp_SelectStoreOrdersPagedWithSortOrder";
            public const string usp_SelectStoreOrderStats = "usp_SelectStoreOrderStats";
            public const string usp_SelectFreeGarmentOrderStats = "usp_SelectFreeGarmentOrderStats";
            public const string usp_SelectStoreOrderStatics = "usp_SelectStoreOrderStatics";
            public const string usp_SelectStoreOrderCount = "usp_SelectStoreOrderCount";
            public const string usp_DeleteFreeOrderGarment = "usp_DeleteFreeOrderGarment";
            public const string usp_SelectStoreProductionSortList = "usp_SelectStoreProductionSortList";
            public const string usp_SelectStoreProductionSortListGradeWise = "usp_SelectStoreProductionSortListGradeWise";


            public const string usp_DeleteFreeGiftGarment = "usp_DeleteFreeGiftGarment";
            public const string usp_DeleteStoreDesign = "usp_DeleteStoreDesign";
            public const string usp_DeleteStoreGarment = "usp_DeleteStoreGarment";
            public const string usp_DeleteStoreGarmentColor = "usp_DeleteStoreGarmentColor";
            public const string usp_DeleteStoreGarmentImages = "usp_DeleteStoreGarmentImages";
            public const string usp_SelectGradeLevels = "usp_SelectGradeLevels";
            public const string usp_SelectGradeLevelsAdmin = "usp_SelectGradeLevelsAdmin";
            public const string usp_AddUpdateStoreGradeLevel = "usp_AddUpdateStoreGradeLevel";
            public const string usp_AddUpdateStoreGradeLevelAdmin = "usp_AddUpdateStoreGradeLevelAdmin";
            public const string usp_SelectStoreTeacherName = "usp_SelectStoreTeacherName";
            public const string usp_GetIsStoreSortingDone = "usp_GetIsStoreSortingDone";
            public const string usp_StoreSortingHeader = "usp_StoreSortingHeader";
            public const string usp_SaveStoreSorting = "usp_SaveStoreSorting";





            public const string usp_SelectUserApprovedArtWork = "usp_SelectUserApprovedArtWork";

            public const string usp_SelectGarmentsForStrore = "usp_SelectGarmentsForStrore";
            public const string usp_SelectStoreArtWorkDesigns = "usp_SelectStoreArtWorkDesigns";
            public const string usp_SelectStoreGarment = "usp_SelectStoreGarment";
            public const string usp_SelectStoreGarmentImages = "usp_SelectStoreGarmentImages";
            public const string usp_SelectStoreGarmentColors = "usp_SelectStoreGarmentColors";
            public const string usp_SelectStoreOrderArtWorks = "usp_SelectStoreOrderArtWorks";
            public const string usp_SelectStoreGarments = "usp_SelectStoreGarments";
            public const string usp_SelectStoreDesign = "usp_SelectStoreDesign";
            public const string usp_SelectStoreImageDisplayType = "usp_SelectStoreImageDisplayType";
            public const string usp_DeleteStoreGarmentImage = "usp_DeleteStoreGarmentImage";
            public const string usp_DeleteStore = "usp_DeleteStore";
            public const string usp_SelectStoreOrderDetail = "usp_SelectStoreOrderDetail";
            public const string usp_SelectStoreOrderItemDetails = "usp_SelectStoreOrderItemDetails";
            public const string usp_FindStoreOrderItemDetails = "usp_FindStoreOrderItemDetails";
            public const string usp_DeleteStoreAndDesign = "usp_DeleteStoreAndDesign";

            public const string usp_SelectStoreOrderDetail_OrderForm = "usp_SelectStoreOrderDetail_OrderForm";
            public const string usp_SelectStoreOrderPaymentRefundList = "usp_SelectStoreOrderPaymentRefundList";


            public const string usp_UpdateStoreOrderPrice = "usp_UpdateStoreOrderPrice";
            public const string usp_SelectStoreGarmentImagebyType = "usp_SelectStoreGarmentImagebyType";
            public const string usp_DeleteStoreOrderLineItem = "usp_DeleteStoreOrderLineItem";
            public const string usp_MergeStoreOrderToOrderTemplate = "usp_MergeStoreOrderToOrderTemplate";
            public const string usp_CheckOrderArtWorkInStoreDesginAvailability = "usp_CheckOrderArtWorkInStoreDesginAvailability";
            public const string usp_UpdateStoreSendMailProfit = "usp_UpdateStoreSendMailProfit";
            public const string usp_DeleteStoreOrder = "usp_DeleteStoreOrder";
            public const string usp_ParmanentDeleteStoreOrder = "usp_ParmanentDeleteStoreOrder";
            public const string usp_StoreApprove = "usp_StoreApprove";
            public const string usp_GetStoreStatus = "usp_GetStoreStatus";
            public const string usp_DeleteGradeLevel = "usp_DeleteGradeLevel";
            public const string usp_DeleteStoreOrderLineItemByGrade = "usp_DeleteStoreOrderLineItemByGrade";
            public const string usp_DeleteStoreOrderAndRefund = "usp_DeleteStoreOrderAndRefund";
            public const string usp_UpdateStoreOrderItemAndRefund = "usp_UpdateStoreOrderItemAndRefund";



            public const string usp_SelectStoreGradeLevel = "usp_SelectStoreGradeLevel";
            public const string usp_AddStoreSelectedGrade = "usp_AddStoreSelectedGrade";
            public const string usp_GetStoreTeacher = "usp_GetStoreTeacher";
            public const string usp_DeleteStoreTeacher = "usp_DeleteStoreTeacher";
            public const string usp_AddUpdateStoreTeacher = "usp_AddUpdateStoreTeacher";
            public const string usp_UpdateStoreDetail = "usp_UpdateStoreDetail";
            public const string usp_GetSelectedOptionType = "usp_GetSelectedOptionType";
            public const string usp_GetStoreGradeColor = "usp_GetStoreGradeColor";
            public const string usp_AddUpdateStoreGradeColor = "usp_AddUpdateStoreGradeColor";
            public const string usp_GetPaymentStatus = "usp_GetPaymentStatus";
            public const string usp_GetPaymentTerms = "usp_GetPaymentTerms";


            /*Store Procedure Related to Base Price*/
            public const string usp_AddUpdateBasePrice = "usp_AddUpdateBasePrice";
            public const string usp_SelectBasePrice = "usp_SelectBasePrice";
            public const string usp_DeleteBasePrice = "usp_DeleteBasePrice";
            public const string usp_SelectBasePrices = "usp_SelectBasePrices";
            public const string usp_SelectBasePricesWithQtyRanges = "usp_SelectBasePricesWithQtyRanges";
            public const string usp_UpdateGarmentBasePriceMarkup = "usp_UpdateGarmentBasePriceMarkup";

            /*Store Procedure Related to EmailTemplate*/
            public const string usp_AddUpdateEmailTemplate = "usp_AddUpdateEmailTemplate";
            public const string usp_SelectEmailTemplate = "usp_SelectEmailTemplate";
            public const string usp_SelectEmailTemplates = "usp_SelectEmailTemplates";

            /*Store Procedure Related to GarmentSuggestion*/
            public const string usp_AddUpdateGarmentSuggestion = "usp_AddUpdateGarmentSuggestion";
            public const string usp_SelectLatestGarmentSuggestion = "usp_SelectLatestGarmentSuggestion";
            public const string usp_SelectGarmentSuggestion = "usp_SelectGarmentSuggestion";
            public const string usp_SelectGarmentSuggestionDetail = "usp_SelectGarmentSuggestionDetail";

            /*Store Procedure Related to Order Status Message*/
            public const string usp_AddUpdateOrderStatusMessage = "usp_AddUpdateOrderStatusMessage";
            public const string usp_SelectOrderStatusMessage = "usp_SelectOrderStatusMessage";
            public const string usp_SelectOrderStatusMessages = "usp_SelectOrderStatusMessages";
            public const string usp_DeleteOrderStatusMessage = "usp_DeleteOrderStatusMessage";

            /*Store Procedure Related to Re Order*/
            public const string usp_AddReOrder = "usp_AddReOrder";

            /*Store Procedure Related to Store Sort Price*/
            public const string usp_AddUpdateStoreSortPrice = "usp_AddUpdateStoreSortPrice";
            public const string usp_GetStoreSortPrice = "usp_GetStoreSortPrice";
            public const string usp_GetStoreSortPrices = "usp_GetStoreSortPrices";
            public const string usp_DeleteStoreSortPrice = "usp_DeleteStoreSortPrice";

            /*Store Procedure Related to Order Store Message*/
            public const string usp_AddUpdateStoreMessage = "usp_AddUpdateStoreMessage";
            public const string usp_SelectStoreMessage = "usp_SelectStoreMessage";
            public const string usp_SelectStoreMessages = "usp_SelectStoreMessages";
            public const string usp_DeleteStoreMessage = "usp_DeleteStoreMessage";


            /*Store Procedure Related to Student Order Form*/
            public const string usp_AddUpdateStudentOrderForm = "usp_AddUpdateStudentOrderForm";
            public const string usp_AddUpdateStudentOrderGarment = "usp_AddUpdateStudentOrderGarment";
            public const string usp_AddUpdateStudentOrderPaymentType = "usp_AddUpdateStudentOrderPaymentType";
            public const string usp_GetStudentOrderForm = "usp_GetStudentOrderForm";
            

            /*Store Procedure Related to AccountCategory*/
            public const string usp_AddUpdateAccountCategory = "usp_AddUpdateAccountCategory";
            public const string usp_CheckAccountCategoryAvailability = "usp_CheckAccountCategoryAvailability";
            public const string usp_GetAccountCategoryPaged = "usp_GetAccountCategoryPaged";
            public const string usp_SelectAccountCategory = "usp_SelectAccountCategory";
            public const string usp_GetAccountCategory = "usp_GetAccountCategory";
            public const string usp_GetDiscountByUser = "usp_GetDiscountByUser";
            public const string GetDiscountByOrderId = "GetDiscountByOrderId";
            /*Store Procedure Related to SchoolYear*/
            public const string usp_AddUpdateSchoolYear = "usp_AddUpdateSchoolYear";
            public const string usp_SelectSchoolYear = "usp_SelectSchoolYear";
            public const string usp_GetSchoolYearPaged = "usp_GetSchoolYearPaged";
            public const string usp_DeleteSchoolYear = "usp_DeleteSchoolYear";
            public const string usp_CheckSchoolYearAvailability = "usp_CheckSchoolYearAvailability";
            public const string usp_GetSchoolCampus = "usp_GetSchoolCampus";
            public const string usp_GetSchoolType = "usp_GetSchoolType";
            public const string usp_GetState = "usp_GetState";
            public const string usp_GetUserProfile = "usp_GetUserProfile";
            public const string usp_GetOrderDiscount = "usp_GetOrderDiscount";
            public const string usp_AddUpdateOrderFreeGiftGarmentSize = "usp_AddUpdateOrderFreeGiftGarmentSize";
            public const string usp_GetFreeGiftGarmentSizes = "usp_GetFreeGiftGarmentSizes";
            public const string usp_GetTotalStoreOrderQtyByStoreDesign = "usp_GetTotalStoreOrderQtyByStoreDesign";
            public const string usp_GetStoreListForMerge = "usp_GetStoreListForMerge";
            public const string usp_GetClosedStoresForNotification = "usp_GetClosedStoresForNotification";
            public const string usp_GetStoresAfterCloseNotification = "usp_GetStoresAfterCloseNotification";
            public const string usp_UpdateStoreCloseSentNotification = "usp_UpdateStoreCloseSentNotification";
            public const string usp_AddUpdateStoreSortingHeader = "usp_AddUpdateStoreSortingHeader";

            public const string usp_GetInkColorByColorCategoryId = "usp_GetInkColorByColorCategoryId";
            public const string usp_GetInkColorsDetails = "usp_GetInkColors"; //add by manoj for adding color  categoryId
            public const string usp_GetColorCategory = "usp_GetColorCategory";
            public const string usp_SelectInkColor = "usp_SelectInkColor";
            public const string usp_DeleteInkColorImages = "usp_DeleteInkColorImages";


        }

        public class Parameter
        {
            public const string Id = "@Id";
            public const string IsDeleteOrder = "@IsDeleteOrder";
            /*Parameter Related to Paging*/
            public const string StartPage = "@StartPage";
            public const string PageLength = "@PageLength";
            public const string NoOfPages = "@NoOfPages";
            public const string TotalRecords = "@TotalRecords";
            public const string SortColumn = "@SortColumn";
            public const string SortOrderBy = "@SortOrderBy";
            public const string ArtworkSubmittedCount = "@ArtworkSubmittedCount";
            public const string ArtWorkInProgressCount = "@ArtWorkInProgressCount";
            public const string ArtWorkApprovedCount = "@ArtWorkApprovedCount";
            public const string CompletedOrderCount = "@CompletedOrderCount";
            public const string OrderCount = "@OrderCount";
            public const string SortOrder = "@SortOrder";
            public const string SortOrderId = "@SortOrderId";
            public const string Email = "@Email";
            public const string FirstName = "@FirstName";
            public const string LastName = "@LastName";
            public const string CurrentPassword = "@CurrentPassword";
            public const string Password = "@Password";
            public const string ProfileImage = "@ProfileImage";
            public const string PhoneNumber = "@PhoneNumber";
            public const string NewPassword = "@NewPassword";
            public const string UserId = "@UserId";
            public const string DateCreated = "@DateCreated";
            public const string IsActive = "@IsActive";
            public const string IsCoverImage = "@IsCoverImage";
            public const string Status = "@Status";
            public const string UpdateStatus = "@UpdateStatus";
            public const string DesignProofId = "@DesignProofId";
            public const string PaymentType = "@PaymentType";
            public const string PaymentResponse = "@PaymentResponse";
            public const string TransactionNo = "@TransactionNo";
            public const string PaymentStatus = "@PaymentStatus";
            public const string UserType = "@UserType";
            public const string TeacherId = "@TeacherId";
            public const string ServiceFee = "@ServiceFee";
            public const string RefundAmount = "@RefundAmount";
            public const string CompleteOrderPaymentStatus = "@CompleteOrderPaymentStatus";



            public const string DeliveryType = "@DeliveryType";
            public const string DeliveredBy = "@DeliveredBy";
            public const string FedexTrakingNo = "@FedexTrakingNo";
            public const string GarmentIdOf5000 = "@GarmentIdOf5000";
            public const string IsCanceled = "@IsCanceled";

            public const string EntityIdIntTableType = "@EntityIdIntTableType";
            public const string LineItemTableType = "@LineItemTableType";
            public const string IdIntEntityIdIntTableType = "@IdIntEntityIdIntTableType";
            public const string IdIntBitTableType = "@IdIntBitTableType";
            public const string IdIntTinyIntTableType = "@IdIntTinyIntTableType";
            public const string IdIntStatusBitTableType = "@IdIntStatusBitTableType";
            public const string EntityColorTableType = "@EntityColorTableType";
            public const string GarmentSizeTableType = "@GarmentSizeTableType";
            public const string DesignTextTableType = "@DesignTextTableType";
            public const string DesignInkColorTableType = "@DesignInkColorTableType";
            public const string DesignPlacementTableType = "@DesignPlacementTableType";
            public const string GarmentPriceTableType = "@GarmentPriceTableType";
            public const string GarmentTypeDesignCategoryTableType = "@GarmentTypeDesignCategoryTableType";
            public const string OrderDesignTextTableType = "@OrderDesignTextTableType";
            public const string OrderDesignQuantityTableType = "@OrderDesignQuantityTableType";
            public const string DecorationTypeXGarmentTableType = "@DecorationTypeXGarmentTableType";
            public const string OrderDesignInkColorTableType = "@OrderDesignInkColorTableType";
            public const string EntityDesignInkColorTableType = "@EntityDesignInkColorTableType";
            public const string ProductionTimeXGarmentTableType = "@ProductionTimeXGarmentTableType";
            public const string OrderPrintPersonalizationTableType = "@OrderPrintPersonalizationTableType";
            public const string RelatedGarmentTableType = "@RelatedGarmentTableType";
            public const string EntityIdInIdTextTableType = "@EntityIdInIdTextTableType";
            public const string OrderStatusTableType = "@OrderStatusTableType";
            public const string OrderTypeTableType = "@OrderTypeTableType";
            public const string GarmentColorTableType = "@GarmentColorTableType";
            public const string GarmentSizeGroupTableType = "@GarmentSizeGroupTableType";
            public const string OrderArtWorkTableType = "@OrderArtWorkTableType";
            public const string FreeOrderGarmentSizeTableType = "@FreeOrderGarmentSizeTableType";
            public const string FreeOrderGarmentTableType = "@FreeOrderGarmentTableType";
            public const string StoreGarmentImagesTableType = "@StoreGarmentImagesTableType";
            public const string StoreGradeLevelTableType = "@StoreGradeLevelTableType";
            public const string DiscountOrderTableType = "@DiscountOrderTableType";
            public const string DiscountGiftGarmentTableType = "@DiscountGiftGarmentTableType";


            public const string StudentOrderGarmentTableType = "@StudentOrderGarmentTableType";
            public const string StudentOrderPaymentTableType = "@StudentOrderPaymentTableType";
            public const string StoreGarmentColorTableType = "@StoreGarmentColorTableType";
            public const string StoreGradeColorTableType = "@StoreGradeColorTableType";


            public const string BrandTableType = "@BrandTableType";
            public const string GarmentGroupTableType = "@GarmentGroupTableType";
            public const string BrandColorTableType = "@BrandColorTableType";
            public const string ProductionTimeTableType = "@ProductionTimeTableType";

            public const string Address1 = "@Address1";
            public const string Address2 = "@Address2";
            public const string AddressType = "@AddressType";
            public const string City = "@City";
            public const string Country = "@Country";
            public const string OrganizationName = "@OrganizationName";
            public const string Phone = "@Phone";
            public const string State = "@State";
            public const string Zip = "@Zip";
            public const string ShipDate = "@ShipDate";
            public const string CompletionDate = "@CompletionDate";

            /*Parameter Related to EntityAttachment*/
            public const string FileId = "@FileId";
            public const string FileExtension = "@FileExtension";
            public const string FileName = "@FileName";
            public const string ThumbFileName = "@ThumbFileName";
            public const string Caption = "@Caption";
            public const string EntityId = "@EntityId";
            public const string EntityType = "@EntityType";
            public const string ContextGuid = "@ContextGuid";
            public const string CurrentDateTime = "@CurrentDateTime";
            public const string EntityColorImageIcon = "@EntityColorImageIcon";
            public const string SizeId = "@SizeId";


            /*Parameter Related to InkColor*/
            public const string ColorName = "@ColorName";
            public const string ColorCode = "@ColorCode";
            public const string ColorId = "@ColorId";
            public const string InkColorType = "@InkColorType";
            public const string ColorSwatch = "@ColorSwatch";
            public const string ColorCategoryId = "@ColorCategoryId";


            /*Parameter Related to Size*/
            public const string SizeName = "@SizeName";
            public const string SizeCode = "@SizeCode";

            /*Parameter Related to Garment Type*/
            public const string Name = "@Name";
            public const string Description = "@Description";
            public const string GarmentTypeImage = "@GarmentTypeImage";
            public const string BasePrice = "@BasePrice";

            /*Parameter Related to Garment size*/
            public const string GroupType = "@GroupType";
            public const string GarmentId = "@GarmentId";
            public const string GarmentPriceId = "@GarmentPriceId";
            public const string EdpRefrenceNo = "@EdpRefrenceNo";
            public const string AdditionalSizePrice = "@AdditionalSizePrice";
            public const string StoreGarmentId = "@StoreGarmentId";
            public const string StoreColorId = "@StoreColorId";
            public const string IsCart = "@IsCart";


            public const string TotalQuantity = "@TotalQuantity";
            public const string TotalFreeShirts = "@TotalFreeShirts";
            /*Parameter Related to Garment*/
            public const string GarmentIcon = "@GarmentIcon";
            public const string GarmentName = "@GarmentName";
            public const string GarmentStyle = "@GarmentStyle";
            public const string GarmentImage = "@GarmentImage";
            public const string GarmentSizeChart = "@GarmentSizeChart";
            public const string GarmentLevel = "@GarmentLevel";
            public const string DiscountInfo = "@DiscountInfo";
            public const string SleevType = "@SleevType";
            public const string NoOfInkColors = "@NoOfInkColors";
            public const string DesignTemplateImage = "@DesignTemplateImage";
            public const string PrintPersonalizationType = "@PrintPersonalizationType";
            public const string RelatedGarmentId = "@RelatedGarmentId";
            public const string GarmentSaleType = "@GarmentSaleType";
            public const string GarmentSaleTypeId = "@GarmentSaleTypeId";
            public const string IsDiscountAllowed = "@IsDiscountAllowed";
            public const string IsDeleted = "@IsDeleted";
            public const string DeletedByUserIP = "@DeletedByUserIP";


            /*Parameter Related to Placement*/
            public const string PlacementPosition = "@PlacementPosition";
            public const string PlacementId = "@PlacementId";
            public const string PlacementType = "@PlacementType";

            /*Parameter Related to Design*/
            public const string ParentId = "@ParentId";
            public const string GarmentTypeId = "@GarmentTypeId";
            public const string DesignName = "@DesignName";
            public const string DesignCode = "@DesignCode";
            public const string CategoryId = "@CategoryId";
            public const string CategoryName = "@CategoryName";
            public const string DesignImage = "@DesignImage";
            public const string DesignId = "@DesignId";
            public const string DesignCategoryImage = "@DesignCategoryImage";
            public const string CategoryHeaderImage = "@CategoryHeaderImage";
            public const string IsFeatured = "@IsFeatured";
            public const string IsMascot = "@IsMascot";
            public const string InkColorId = "@InkColorId";
            public const string TopFeatureDesign = "@TopFeatureDesign";
            public const string OrderLineItemId = "@OrderLineItemId";
            public const string LineItemId = "@LineItemId";
            public const string SearchKeyword = "@SearchKeyword";
            public const string DesignTextType = "@DesignTextType";
            public const string TransparentImage = "@TransparentImage";
            public const string Type = "@Type";


            /*Parameter Related to Design Proof*/
            public const string BackDesignPlacementId = "@BackDesignPlacementId";
            public const string FrontDesignPlacementId = "@FrontDesignPlacementId";
            public const string DesignStyle = "@DesignStyle";
            public const string DesignStyleId = "@DesignStyleId";
            public const string FrontDesignText = "@FrontDesignText";
            public const string BackDesignText = "@BackDesignText";
            public const string NoteForDesinger = "@NoteForDesinger";

            /*Parameter Related to Mascot*/
            public const string MascotImage = "@MascotImage";
            public const string MascotId = "@MascotId";

            /*Parameter Related to Cms Page*/
            public const string PageName = "@PageName";
            public const string PageContent = "@PageContent";
            public const string PageUrl = "@PageUrl";

            /*Parameter Related to Testimonial*/
            public const string CompanyName = "@CompanyName";
            public const string Comment = "@Comment";
            public const string EmailAddress = "@EmailAddress";
            public const string IPAddress = "@IPAddress";
            public const string DesignCategoryId = "@DesignCategoryId";
            public const string Rating = "@Rating";
            public const string TestimonialPicture = "@TestimonialPicture";
            public const string WouldYouRecommendSw = "@WouldYouRecommendSw";
            public const string WouldYouOrderAgain = "@WouldYouOrderAgain";

            public const string MinQty = "@MinQty";
            public const string MaxQty = "@MaxQty";
            public const string PrintType = "@PrintType";
            public const string DesignType = "@DesignType";
            public const string DesignOption = "@DesignOption";
            public const string QuantityType = "@QuantityType";
            public const string IsBackDesignCategory = "@IsBackDesignCategory";
            public const string ItemPrice = "@ItemPrice";
            public const string TotalItemPrice = "@TotalItemPrice";
            public const string BackDesignItemPrice = "@BackDesignItemPrice";
            public const string SleeveDesignItemPrice = "@SleeveDesignItemPrice";

            /*Parameter Related to Order*/
            public const string Price = "@Price";
            public const string GrandTotalPrice = "@GrandTotalPrice";
            public const string StoreOrderType = "@StoreOrderType";
            public const string ShippingPrice = "@ShippingPrice";
            public const string OrderNumber = "@OrderNumber";
            public const string SubStatusMessage = "@SubStatusMessage";
            public const string OrderInvoice = "@OrderInvoice";
            public const string OrderInvoiceFile = "@OrderInvoiceFile";
            public const string PurchaseOrder = "@PurchaseOrder";
            public const string PaidToSchoolName = "@PaidToSchoolName";
            public const string TaxExemptFile = "@TaxExemptFile";
            public const string ShipToSchoolAdress = "@ShipToSchoolAdress";
            public const string Quantity = "@Quantity";
            public const string GarmentColor = "@GarmentColor";
            public const string GarmentColorCode = "@GarmentColorCode";
            public const string DecorationType = "@DecorationType";
            public const string DecorationTypeId = "@DecorationTypeId";
            public const string IsBackDesign = "@IsBackDesign";
            public const string OrderId = "@OrderId";
            public const string FreeOrderGarmentId = "@FreeOrderGarmentId";
            public const string UpdatedBy = "@UpdatedBy";
            public const string DesignPlacement = "@DesignPlacement";
            public const string Mascot = "@Mascot";
            public const string TotalPrice = "@TotalPrice";
            public const string DiscountPrice = "@DiscountPrice";
            public const string DiscountId = "@DiscountId";
            public const string SleevText = "@SleevText";
            public const string ParentLineItemId = "@ParentLineItemId";
            public const string ParentOrderId = "@ParentOrderId";
            public const string QtyId = "@QtyId";
            public const string DiscountedItemPrice = "@DiscountedItemPrice";
            public const string PointToRedeem = "@PointToRedeem";
            public const string AmountToRedeem = "@AmountToRedeem";
            public const string OrderType = "@OrderType";
            public const string InvoiceNo = "@InvoiceNo";
            public const string InvoiceStatus = "@InvoiceStatus";
            public const string OrderInvoiceStatus = "@OrderInvoiceStatus";
            public const string AdminPurchaseOrderNo = "@AdminPurchaseOrderNo";
            public const string ServiceTaxPercent = "@ServiceTaxPercent";
            public const string OtherTitle = "@OtherTitle";
            public const string DeliveryDetail = "@DeliveryDetail";
            public const string IsSorted = "@IsSorted";
            public const string SortedPrice = "@SortedPrice";
            public const string GradeLevelLabelName = "@GradeLevelLabelName";
            public const string IsFinalSubmitByOwner = "@IsFinalSubmitByOwner";
            public const string CountSubmitedContactInfo = "@CountSubmitedContactInfo";
            public const string CountSubmitedStoreDetails = "@CountSubmitedStoreDetails";
            public const string RefOrderArtWorkId = "@RefOrderArtWorkId";
            public const string RefOrderInvoiceId = "@RefOrderInvoiceId";
            public const string ArtworkORInvoiceId = "@ArtworkORInvoiceId";
            public const string IsRetired = "@IsRetired";


            /*Parameter Related to Discount*/
            public const string PromoCode = "@PromoCode";
            public const string GlobalDiscountAmount = "@GlobalDiscountAmount";
            public const string DiscountType = "@DiscountType";
            public const string StartDate = "@StartDate";
            public const string EndDate = "@EndDate";
            public const string StartFrom = "@StartFrom";
            public const string EndsOn = "@EndsOn";
            public const string DiscountValue = "@DiscountValue";
            public const string IsLimitReached = "@IsLimitReached";
            public const string IsExpired = "@IsExpired";
            public const string UsedQuantities = "@UsedQuantities";
            public const string CanCombined = "@CanCombined";
            public const string FreeShirts = "@FreeShirts";
            public const string OnEveryGarment = "@OnEveryGarment";
            public const string NoOfGarments = "@NoOfGarments";
            public const string CombinedDiscountId = "@CombinedDiscountId";
            public const string AccountCategory = "@AccountCategory";
            public const string PromoType = "@PromoType";
            public const string IsGiftFree = "@IsGiftFree";
            public const string GiftNoOfGarments = "@GiftNoOfGarments";
            public const string GiftFreeShirts = "@GiftFreeShirts";
            public const string SYId = "@SYId";
            public const string AccountMode = "@AccountMode";
            public const string IsGlobalPromo = "@IsGlobalPromo";

            public const string ProductionTimeId = "@ProductionTimeId";
            public const string NoteForDesigner = "@NoteForDesigner";

            public const string Title = "@Title";
            public const string ProductiontimeImage = "@ProductiontimeImage";
            public const string Summary = "@Summary";
            public const string ShipingInDays = "@ShipingInDays";
            public const string AdditionalCharges = "@AdditionalCharges";
            public const string DefaultGarmentColorId = "@DefaultGarmentColorId";
            public const string PromoCodeQuantities = "@PromoCodeQuantities";


            public const string SaleTypeImage = "@SaleTypeImage";
            public const string SaleTypeTitle = "@SaleTypeTitle";


            /*Resource related Db Paramenter*/
            public const string ResourceKey = "@ResourceKey";
            public const string ResourceValue = "@ResourceValue";
            public const string CultureName = "@CultureName";

            /*Parameter Related to Conversation*/
            public const string CommentText = "@CommentText";
            public const string ToUserId = "@ToUserId";
            public const string FromUserId = "@FromUserId";
            public const string IsArtWorkApproved = "@IsArtWorkApproved";
            public const string ConversationFileName = "@ConversationFileName";
            public const string ArtWorkStatus = "@ArtWorkStatus";
            public const string IsCategoryHomePageTemplate = "@IsCategoryHomePageTemplate";
            public const string IsMessageUnread = "@IsMessageUnread";

            /*Resource related Db Paramenter*/
            public const string SchoolName = "@SchoolName";
            public const string ProblemId = "@ProblemId";
            public const string CreatedBy = "@CreatedBy";
            public const string ProblemType = "@ProblemType";
            public const string TicketSubject = "@TicketSubject";

            /*Db Paramenter Related to Brand*/
            public const string BrandName = "@BrandName";
            public const string BrandId = "@BrandId";
            public const string BrandColorId = "@BrandColorId";

            /*Db Paramenter Related to Garment Color Images*/
            public const string GarmentColorId = "@GarmentColorId";
            public const string BackImage = "@BackImage";
            public const string FrontImage = "@FrontImage";
            public const string SideImage = "@SideImage";
            public const string ModelImage = "@ModelImage";
            public const string YouthModelImage = "@YouthModelImage";            
            public const string IsDefault = "@IsDefault";

            /*Db Paramenter Related to Broucher Images*/
            public const string BroucherImage = "@BroucherImage";
            public const string BroucherUrl = "@BroucherUrl";

            /*Db Paramenter Related to Sw District*/
            public const string QueryType = "@QueryType";
            public const string DistrictName = "@DistrictName";
            public const string SearchTxt = "@SearchTxt";
            public const string SearchKey = "@SearchKey";
            public const string DistrictId = "@DistrictId";

            /*Db Columns Related to Order ArtWork*/
            public const string ArtWorkNo = "@ArtWorkNo";
            public const string ArtWorkFileName = "@ArtWorkFileName";
            public const string ConversationId = "@ConversationId";

            /*Parameter Related to StoreDetail*/
            public const string StoreName = "@StoreName";
            public const string StoreCode = "@StoreCode";
            public const string StoreDescription = "@StoreDescription";
            public const string StoreColor = "@StoreColor";
            public const string TitleId = "@TitleId";
            public const string Organization = "@Organization";
            public const string PhoneNo = "@PhoneNo";
            public const string IsEmailShow = "@IsEmailShow";
            public const string CheckPayableTo = "@CheckPayableTo";
            public const string MailingAddress = "@MailingAddress";
            public const string OpenDate = "@OpenDate";
            public const string CloseDate = "@CloseDate";
            public const string DeliveryDate = "@DeliveryDate";
            public const string ProfitEmailDate = "@ProfitEmailDate";
            public const string IsFundraising = "@IsFundraising";
            public const string FundAmount = "@FundAmount";
            public const string FundraisingItemQty = "@FundraisingItemQty";
            public const string FundraisingDesc = "@FundraisingDesc";
            public const string StoreId = "@StoreId";
            public const string IsInOrder = "@IsInOrder";
            public const string StoreProfiltAmt = "@StoreProfiltAmt";
            public const string StoreDesignId = "@StoreDesignId";
            public const string IsGarment5000 = "@IsGarment5000";
            public const string EstimatedOrderQty = "@EstimatedOrderQty";
            public const string SWPrice = "@SWPrice";
            public const string StorePrice = "@StorePrice";
            public const string OrderArtWorkId = "@OrderArtWorkId";
            public const string StoreGarmentColorId = "@StoreGarmentColorId";
            public const string ImageDisplayType = "@ImageDisplayType";
            public const string ImageName = "@ImageName";
            public const string StoreUserId = "@StoreUserId";
            public const string StoreOrderId = "@StoreOrderId";
            public const string IsSoftDelete = "@IsSoftDelete";
            public const string CreditCardNo = "@CreditCardNo";
            public const string CardType = "@CardType";
            public const string ZipCode = "@ZipCode";
            public const string approveOrderArtWork = "@approveOrderArtWork";
            public const string StoreStatus = "@StoreStatus";
            public const string ReturnValue = "@ReturnValue";
            public const string TaxAplicable = "@TaxAplicable";
            public const string OrderTotal = "@OrderTotal";
            public const string IsServiceFeeFromStoreProfit = "@IsServiceFeeFromStoreProfit";
            public const string IsRefunded = "@IsRefunded";
            public const string HeaderId = "@HeaderId";
            public const string HeaderName = "@HeaderName";
            public const string LastStoreId = "@LastStoreId";

            public const string Level1BasePrice = "@Level1BasePrice";
            public const string Level2BasePrice = "@Level2BasePrice";
            public const string Level3BasePrice = "@Level3BasePrice";
            public const string Level4BasePrice = "@Level4BasePrice";

            public const string BasePriceMarkUp = "@BasePriceMarkUp";
            public const string RoundUpValue = "@RoundUpValue";
            public const string MarkUpPercent = "@MarkUpPercent";
            public const string ToDate = "@ToDate";
            public const string FromDate = "@FromDate";
            public const string TotalProfit = "@TotalProfit";
            public const string TotalSWPrice = "@TotalSWPrice";
            public const string TotalStorePrice = "@TotalStorePrice";
            public const string TotalSaleTaxAmount = "@TotalSaleTaxAmount";
            public const string StudentName = "@StudentName";
            public const string StudentLastName = "@StudentLastName";
            public const string GradeLevelId = "@GradeLevelId";
            public const string StudentGrade = "@StudentGrade";
            public const string StudentTeacher = "@StudentTeacher";



            public const string StoreSaleAmount = "@StoreSaleAmount";
            public const string StoreSaleTaxAmount = "@StoreSaleTaxAmount";
            public const string SortingCost = "@SortingCost";
            public const string StoreSaleQty = "@StoreSaleQty";
            public const string BullkOrderQty = "@BullkOrderQty";

            public const string EmailContent = "@EmailContent";
            public const string SubjectName = "@SubjectName";
            public const string TemplateType = "@TemplateType";
            public const string MessageBoardText = "@MessageBoardText";

            public const string ArtworkId = "@ArtworkId";
            public const string Front = "@Front";
            public const string Back = "@Back";
            public const string DecorationId = "@DecorationId";
            public const string Location3Name = "@Location3Name";
            public const string Location3 = "@Location3";
            public const string Location4Name = "@Location4Name";
            public const string Location4 = "@Location4";
            public const string HeatPress = "@HeatPress";
            public const string CurrentGarmentId = "@CurrentGarmentId";


            public const string Message = "@Message";
            public const string SMSMessage = "@SMSMessage";
            public const string FAQMessage = "@FAQMessage";
            public const string ScheduleCompletionDate = "@ScheduleCompletionDate";
            public const string GarmentSuggestionId = "@GarmentSuggestionId";
            public const string ApprovedArtWorkFileName = "@ApprovedArtWorkFileName";
            public const string ReOrderId = "@ReOrderId";
            public const string AdditionalPricePerItem = "@AdditionalPricePerItem";
            public const string StoreSelectedGradeTableType = "@StoreSelectedGradeTableType";
            public const string IsSelected = "@IsSelected";
            public const string StoreTeacherTableType = "@StoreTeacherTableType";
            public const string PlanType = "@PlanType";


            /*Parameter Related to Store SortPrice*/
            public const string SortPrice = "@SortPrice";

            /*Parameter Related to Store Message*/
            public const string MessageVideoType = "@MessageVideoType";
            public const string MessageType = "@MessageType";
            public const string EmojiImage = "@EmojiImage";
            public const string VideoType = "@VideoType";
            public const string VideoUrl = "@VideoUrl";
            public const string VideoToolTip = "@VideoToolTip";

            public const string ChequePayableTo = "@ChequePayableTo";
            public const string IsIncludeStoreLink = "@IsIncludeStoreLink";
            public const string OrderTitle = "@OrderTitle";
            public const string ReturnOrderFormBy = "@ReturnOrderFormBy";
            public const string ReturnOrderFormTo = "@ReturnOrderFormTo";
            public const string SpecialInstructions = "@SpecialInstructions";


            /*Parameter Related to AccountCategory*/
            public const string AccountType = "@AccountType";
            public const string IsFreeGift = "@IsFreeGift";
            public const string IsUserPromo = "@IsUserPromo";
            public const string UserPromoId = "@UserPromoId";

            /*Parameter Related to State*/
            public const string StateName = "@StateName";
            public const string StateCode = "@StateCode";

            /*Parameter Related to Schoole Campus*/
            public const string CampusName = "@CampusName";
            public const string SchoolCampusId = "@SchoolCampusId";

            public const string StateId = "@StateId";
            public const string SchoolDistrict = "@SchoolDistrict";
            public const string ApprovedVendor = "@ApprovedVendor";
            public const string IsTaxExempt = "@IsTaxExempt";
            public const string SchoolTypeId = "@SchoolTypeId";
            public const string TaxExempt = "@TaxExempt";
            public const string SchoolTypeName = "@SchoolTypeName";

            public const string PhoneNumberType = "@PhoneNumberType";

            public const string OrderFreeGiftGarmentSizeTableType = "@OrderFreeGiftGarmentSizeTableType";
            public const string FreeGiftDesign = "@FreeGiftDesign";
            public const string FreeGiftAvailableQty = "@FreeGiftAvailableQty";
            public const string FreeGiftQty = "@FreeGiftQty";
            public const string PurchaseOrderFile = "@PurchaseOrderFile";

            public const string DueAmount = "@DueAmount";
            public const string IsPaymentRequired = "@IsPaymentRequired";
            public const string PaymentTerms = "@PaymentTerms";
            public const string DueDate = "@DueDate";
            public const string QCStatus = "@QCStatus";
            public const string PaymentRemarks = "@PaymentRemarks";
            public const string IsSchoolDistrictExempt = "@IsSchoolDistrictExempt";
            public const string Desgin1QtyRange = "@Desgin1QtyRange";
            public const string Desgin2QtyRange = "@Desgin2QtyRange";
            public const string CreditCardFee = "@CreditCardFee";
            public const string IsOrderForm = "@IsOrderForm";
            public const string PaymentNote = "@PaymentNote";
            public const string CheckNumber = "@CheckNumber";
            public const string PayableAmount = "@PayableAmount";
            public const string GroupName = "@GroupName";
            public const string ProfitCheckAmount = "@ProfitCheckAmount";
            public const string IsGlobalPromoApplied = "@IsGlobalPromoApplied";
            public const string InvoiceEmail = "@InvoiceEmail";
            public const string CellPhone = "@CellPhone";
            public const string IsNotifications = "@IsNotifications";


            /*Parameter Related to Financial Statement*/
            public const string CreditCardFees = "@CreditCardFees";
            public const string Design1Invoice = "@Design1Invoice";
            public const string Design2Invoice = "@Design2Invoice";
            public const string Design1InvoiceAmount = "@Design1InvoiceAmount";
            public const string Design2InvoiceAmount = "@Design2InvoiceAmount";
            public const string EstimatedProfit = "@EstimatedProfit";
            public const string OnlineSalesProfit = "@OnlineSalesProfit";
            public const string OnlineTotalAmount = "@OnlineTotalAmount";
            public const string OnlineTotalQty = "@OnlineTotalQty";
            public const string OrderFormTotalAmount = "@OrderFormTotalAmount";
            public const string OrderFormTotalQuantity = "@OrderFormTotalQuantity";
            public const string OtherCreditAmount1 = "@OtherCreditAmount1";
            public const string OtherCreditAmount2 = "@OtherCreditAmount2";
            public const string OtherCreditAmount3 = "@OtherCreditAmount3";
            public const string OtherCreditDescriptions1 = "@OtherCreditDescriptions1";
            public const string OtherCreditDescriptions2 = "@OtherCreditDescriptions2";
            public const string OtherCreditDescriptions3 = "@OtherCreditDescriptions3";
            public const string OtherDeductionAmount1 = "@OtherDeductionAmount1";
            public const string OtherDeductionAmount2 = "@OtherDeductionAmount2";
            public const string OtherDeductionAmount3 = "@OtherDeductionAmount3";
            public const string OtherDeductionDescriptions1 = "@OtherDeductionDescriptions1";
            public const string OtherDeductionDescriptions2 = "@OtherDeductionDescriptions2";
            public const string OtherDeductionDescriptions3 = "@OtherDeductionDescriptions3";
            public const string RefundFees = "@RefundFees";
            public const string SortFees = "@SortFees";
            public const string IsFromDashboard = "@IsFromDashboard";

            public const string InkColorImage1 = "@InkColorImage1";
            public const string InkColorImage2 = "@InkColorImage2";
            public const string InkColorImage3 = "@InkColorImage3";
            public const string InkColorCodeImage = "@InkColorCodeImage";
            public const string InkColorCategoryId = "@InkColorCategoryId";
            public const string Display = "@Display";

            public const string InkColor1 = "@InkColor1";
            public const string InkColor2 = "@InkColor2";
            public const string InkColor3 = "@InkColor3";




        }

        public class DbColumn
        {
            public const string UserId = "UserId";
            public const string TroubleTicketCount = "TroubleTicketCount";
            public const string DateCreated = "DateCreated";
            public const string StoreCreatedDate = "StoreCreatedDate";
            public const string DateUpdated = "DateUpdated";
            public const string StoreOpenDate = "StoreOpenDate";
            public const string IsActive = "IsActive";
            public const string IsCoverImage = "IsCoverImage";
            public const string Status = "Status";
            public const string UserType = "UserType";
            public const string ToUserType = "ToUserType";
            public const string FromUserType = "FromUserType";
            public const string Email = "Email";
            public const string Location = "Location";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string Password = "Password";
            public const string ProfileImage = "ProfileImage";
            public const string PhoneNumber = "PhoneNumber";
            public const string IsFeatured = "IsFeatured";
            public const string Id = "Id";
            public const string Address = "Address";
            public const string City = "City";
            public const string State = "State";
            public const string Zip = "Zip";
            public const string Phone = "Phone";
            public const string IsCurrentStatus = "IsCurrentStatus";
            public const string StatusDetail = "StatusDetail";
            public const string StudentName = "StudentName";
            public const string StudentLastName = "StudentLastName";
            public const string GradeTeacherStudentName = "GradeTeacherStudentName";
            public const string IsGarmentNotAddedInDesign = "IsGarmentNotAddedInDesign";
            public const string IsDesignAvailable = "IsDesignAvailable";
            public const string IsGradeUsed = "IsGradeUsed";


            public const string InkColorImage1 = "ColorImage1";
            public const string InkColorImage2 = "ColorImage2";
            public const string InkColorImage3 = "ColorImage3";
            public const string InkColorCodeImage = "ColorCodeImage";

            public const string ColorCategoryId = "ColorCategoryId";
            public const string ColorCategory = "ColorCategory";
            public const string PrintColorId = "PrintColorId";
            public const string InkColor1 = "InkColor1";
            public const string InkColor2 = "InkColor2";
            public const string InkColor3 = "InkColor3";





            /*DbColumn Related to EntityAttachment*/
            public const string FileId = "FileId";
            public const string FileExtension = "FileExtension";
            public const string FileName = "FileName";
            public const string UpdatedBy = "UpdatedBy";
            public const string ThumbFileName = "ThumbFileName";
            public const string EntityId = "EntityId";
            public const string EntityType = "EntityType";
            public const string ContextGuid = "ContextGuid";
            public const string Caption = "Caption";
            public const string LinkUrl = "LinkUrl";
            public const string StoreGarmentId = "StoreGarmentId";
            public const string LineItemId = "LineItemId";
            public const string StoreColorId = "StoreColorId";

            public const string PaidToSchoolName = "PaidToSchoolName";
            public const string TaxExemptFile = "TaxExemptFile";
            public const string ShipToSchoolAdress = "ShipToSchoolAdress";
            /*DbColumn Related to Ink color*/
            public const string ColorName = "ColorName";
            public const string ColorCode = "ColorCode";
            public const string ColorId = "ColorId";
            public const string EntityColorImage = "EntityColorImage";
            public const string InkColorType = "InkColorType";
            public const string ColorSwatch = "ColorSwatch";
            public const string ServiceTaxPercentDB = "ServiceTaxPercentDB"; //Gajendra ST
            public const string TotalSizeQty = "TotalSizeQty";
            public const string Is5000Garment = "Is5000Garment";
            public const string SortingStatus = "SortingStatus";
            public const string IsOrderPlaced = "IsOrderPlaced";




            /*DbColumn Related to Size*/
            public const string SizeName = "SizeName";
            public const string SizeCode = "SizeCode";
            public const string SizeId = "SizeId";
            public const string NewSizeId = "NewSizeId";

            /*DbColumn Related to Garment Type*/
            public const string Name = "Name";
            public const string Description = "Description";
            public const string GarmentTypeImage = "GarmentTypeImage";
            public const string ParentName = "ParentName";
            public const string SleevType = "SleevType";
            public const string DesignOption = "DesignOption";
            public const string GarmentSaleType = "GarmentSaleType";
            public const string GarmentSaleTypeId = "GarmentSaleTypeId";
            public const string SaleTypeTitle = "SaleTypeTitle";
            public const string SaleTypeImage = "SaleTypeImage";
            public const string GarmentLevel = "GarmentLevel";

            /*DbColumn Related to Garment size*/
            public const string GroupType = "GroupType";
            public const string GarmentId = "GarmentId";
            public const string TotalQuantity = "TotalQuantity";
            public const string FreeOrderGarmentId = "FreeOrderGarmentId";
            public const string GramentColorFrontImage = "GramentColorFrontImage";
            public const string StoreGramentColorFrontImage = "StoreGramentColorFrontImage";
            public const string GramentColorBackImage = "GramentColorBackImage";
            public const string StoreGramentColorBackImage = "StoreGramentColorBackImage";
            public const string PayableAmount = "PayableAmount";


            /*DbColumn Related to Garment Price*/
            public const string Price = "Price";
            public const string GrandTotalPrice = "GrandTotalPrice";
            public const string ProductionTimeId = "ProductionTimeId";
            public const string ShippingPrice = "ShippingPrice";
            public const string ServiceTaxPercent = "ServiceTaxPercent";
            public const string ShirtType = "ShirtType";
            public const string PrintType = "PrintType";
            public const string QuantityType = "QuantityType";
            public const string QtyId = "QtyId";
            public const string ItemPrice = "ItemPrice";
            public const string TotalItemPrice = "TotalItemPrice";
            public const string SleeveDesignItemPrice = "SleeveDesignItemPrice";
            public const string BackDesignItemPrice = "BackDesignItemPrice";
            public const string TotalPrice = "TotalPrice";
            public const string DiscountPrice = "DiscountPrice";
            public const string GlobalDiscountAmount = "GlobalDiscountAmount";
            public const string DiscountId = "DiscountId";
            public const string NoteForDesigner = "NoteForDesigner";
            public const string PurchaseOrder = "PurchaseOrder";
            public const string GarmentNameWithStyle = "GarmentNameWithStyle";



            /*DbColumn Related to Design*/
            public const string TextDesign = "TextDesign";
            public const string DesignId = "DesignId";
            public const string InkColorName = "InkColorName";
            public const string InkColorCode = "InkColorCode";
            public const string DesignSvg = "DesignSvg";
            public const string DesignInkColorId = "DesignInkColorId";

            /*DbColumn Related to Design*/
            public const string ParentId = "ParentId";
            public const string GarmentTypeId = "GarmentTypeId";
            public const string DesignName = "DesignName";
            public const string DesignCode = "DesignCode";
            public const string CategoryId = "CategoryId";
            public const string DesignImage = "DesignImage";
            public const string DesignCategoryImage = "DesignCategoryImage";
            public const string CategoryHeaderImage = "CategoryHeaderImage";
            public const string ParentCategoryHeaderImage = "ParentCategoryHeaderImage";
            public const string IsMascot = "IsMascot";
            public const string InkColorId = "InkColorId";
            public const string DesignCategoryName = "DesignCategoryName";
            public const string DesignCategoryId = "DesignCategoryId";
            public const string GarmentTypeName = "GarmentTypeName";
            public const string CategorySortOrder = "CategorySortOrder";
            public const string TransparentImage = "TransparentImage";
            public const string StoreTotalColor = "StoreTotalColor";
            public const string NoOfColorAssign = "NoOfColorAssign";

            /*Parameter Related to Placement*/
            public const string PlacementPosition = "PlacementPosition";
            public const string PlacementId = "PlacementId";
            public const string PlacementType = "PlacementType";

            /*Parameter Related to Mascot*/
            public const string MascotImage = "MascotImage";
            public const string MascotId = "MascotId";

            /*DbColumn Related to Cms Page*/
            public const string PageName = "PageName";
            public const string PageContent = "PageContent";
            public const string PageUrl = "PageUrl";

            /*DbColumn Related to Testimonial*/
            public const string CompanyName = "CompanyName";
            public const string Comment = "Comment";
            public const string EmailAddress = "EmailAddress";
            public const string IPAddress = "IPAddress";
            public const string Rating = "Rating";
            public const string TestimonialPicture = "TestimonialPicture";
            public const string WouldYouRecommendSw = "WouldYouRecommendSw";
            public const string WouldYouOrderAgain = "WouldYouOrderAgain";

            /*Parameter Related to Garment*/
            public const string GarmentIcon = "GarmentIcon";
            public const string GarmentName = "GarmentName";
            public const string GarmentStyle = "GarmentStyle";
            public const string DiscountInfo = "DiscountInfo";
            public const string GarmentImage = "GarmentImage";
            public const string GarmentColorImage = "GarmentColorImage";
            public const string StoreGarmentImageName = "StoreGarmentImageName";
            public const string GarmentSizeChart = "GarmentSizeChart";
            public const string RelatedGarmentId = "RelatedGarmentId";
            public const string RelatedId = "RelatedId";
            public const string IsDiscountAllowed = "IsDiscountAllowed";

            public const string EntityColorImageIcon = "EntityColorImageIcon";
            public const string MinQty = "MinQty";
            public const string MaxQty = "MaxQty";
            public const string QuantityRange = "QuantityRange";
            public const string DesignType = "DesignType";
            public const string SortOrder = "SortOrder";
            public const string EdpRefrenceNo = "EdpRefrenceNo";
            public const string AdditionalSizePrice = "AdditionalSizePrice";
            public const string IsBackDesignCategory = "IsBackDesignCategory";
            public const string DesignTextType = "DesignTextType";
            public const string IndividualDesignType = "IndividualDesignType";
            public const string NoOfArtWorksUploaded = "NoOfArtWorksUploaded";
            public const string NoOfRejectedArtWork = "NoOfRejectedArtWork";

            /*Column Related to Garment*/
            public const string Quantity = "Quantity";
            public const string GarmentColor = "GarmentColor";
            public const string GarmentColorCode = "GarmentColorCode";
            public const string DecorationType = "DecorationType";
            public const string DecorationTypeName = "DecorationTypeName";


            public const string IsBackDesign = "IsBackDesign";
            public const string OrderId = "OrderId";
            public const string OrderLineItemId = "OrderLineItemId";
            public const string OrderPrintPersonalizationId = "OrderPrintPersonalizationId";
            public const string IndividualNumber = "IndividualNumber";
            public const string IndividualName = "IndividualName";
            public const string DesignText = "DesignText";
            public const string DesignTextId = "DesignTextId";
            public const string DesignPlacement = "DesignPlacement";
            public const string MascotDesign = "MascotDesign";
            public const string Mascot = "Mascot";
            public const string SleevText = "SleevText";
            public const string Size = "Size";
            public const string NoOfInkColors = "NoOfInkColors";
            public const string DesignTemplateImage = "DesignTemplateImage";
            public const string ApprovedArtWorkFileName = "ApprovedArtWorkFileName";
            public const string OrderQtyId = "OrderQtyId";
            public const string OrderDesignQuantityId = "OrderDesignQuantityId";
            public const string ShipDate = "ShipDate";
            public const string IsArtWorkUploaded = "IsArtWorkUploaded";
            public const string OrderInvoiceStatus = "OrderInvoiceStatus";

            public const string Address1 = "Address1";
            public const string Address2 = "Address2";
            public const string AddressType = "AddressType";
            public const string Country = "Country";
            public const string OrganizationName = "OrganizationName";
            public const string ParentLineItemId = "ParentLineItemId";
            public const string UniqueId = "UniqueId";
            public const string BasePrice = "BasePrice";
            public const string DecorationTypeId = "DecorationTypeId";
            public const string QtyRangeName = "QtyRangeName";
            public const string DecorationTypeXGarmentId = "DecorationTypeXGarmentId";
            public const string IsAdded = "IsAdded";
            public const string DiscountedItemPrice = "DiscountedItemPrice";
            public const string OrderNumber = "OrderNumber";
            public const string Discount = "Discount";
            public const string IsStoreCreated = "IsStoreCreated";
            public const string Savings = "Savings";
            public const string TemplateId = "TemplateId";
            public const string PaymentStatus = "PaymentStatus";
            public const string PaymentTerms = "PaymentTerms";
            public const string NoOfDays = "NoOfDays";
            public const string PaymentNote = "PaymentNote";
            public const string GlobalPromoCode = "GlobalPromoCode";

            public const string ChequePayableTo = "ChequePayableTo";
            public const string ReturnOrderFormTo = "ReturnOrderFormTo";
            public const string ReturnOrderFormBy = "ReturnOrderFormBy";
            public const string SpecialInstructions = "SpecialInstructions";
            public const string OrderTitle = "OrderTitle";
            public const string IsIncludeStoreLink = "IsIncludeStoreLink";

            public const string GarmentPrice = "GarmentPrice";
            public const string NoOfColors = "NoOfColors";
            public const string StudentOrderFormId = "StudentOrderFormId";
            



            public const string DueAmount = "DueAmount";
            public const string IsPaymentRequired = "IsPaymentRequired";
            public const string DueDate = "DueDate";
            public const string QCStatus = "QCStatus";
            public const string PaymentStatusString = "PaymentStatusString";
            public const string PaymentTermsString = "PaymentTermsString";
            public const string PaymentRemarks = "PaymentRemarks";
            public const string OrderTotal = "OrderTotal";
            public const string RefundAmount = "RefundAmount";
            public const string ServiceFee = "ServiceFee";
            public const string IsServiceFeeFromStoreProfit = "IsServiceFeeFromStoreProfit";
            public const string IsStore2ndDesign = "IsStore2ndDesign";


            public const string TransactionNo = "TransactionNo";
            public const string PaymentResponse = "PaymentResponse";
            public const string SubStatusMessage = "SubStatusMessage";
            public const string InvoiceNo = "InvoiceNo";
            public const string OrderInvoice = "OrderInvoice";
            /*Column Related to Discount*/
            public const string PromoCode = "PromoCode";
            public const string DiscountType = "DiscountType";
            public const string Value = "Value";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string StartFrom = "StartFrom";
            public const string EndsOn = "EndsOn";
            public const string DiscountValue = "DiscountValue";
            public const string IsLimitReached = "IsLimitReached";
            public const string IsExpired = "IsExpired";
            public const string UsedQuantities = "UsedQuantities";
            public const string CanCombined = "CanCombined";
            public const string NoOfGarments = "NoOfGarments";
            public const string FreeShirts = "FreeShirts";
            public const string OnEveryGarment = "OnEveryGarment";
            public const string PromoCodeQuantities = "PromoCodeQuantities";
            public const string PaymentType = "PaymentType";
            public const string StoreOrderType = "StoreOrderType";
            public const string CombinedDiscountId = "CombinedDiscountId";
            public const string AccountCategory = "AccountCategory";
            public const string AccountCategoryId = "AccountCategoryId";
            public const string PromoType = "PromoType";
            public const string IsGiftFree = "IsGiftFree";
            public const string GiftNoOfGarments = "GiftNoOfGarments";
            public const string GiftFreeShirts = "GiftFreeShirts";
            public const string SYId = "SYId";
            public const string UserPromoId = "UserPromoId";
            public const string AccountMode = "AccountMode";
            public const string IncrementalDiscountValue = "IncrementalDiscountValue";
            public const string IsGlobalPromo = "IsGlobalPromo";
            public const string IsGlobalPromoUsed = "IsGlobalPromoUsed";
            public const string IsPromoCodeValidDate = "IsPromoCodeValidDate";





            /*Parameter Related to Design Proof*/
            public const string BackDesignPlacementId = "BackDesignPlacementId";
            public const string FrontDesignPlacementId = "FrontDesignPlacementId";
            public const string DesignStyle = "DesignStyle";
            public const string DesignStyleId = "DesignStyleId";
            public const string FrontDesignText = "FrontDesignText";
            public const string BackDesignText = "BackDesignText";
            public const string NoteForDesinger = "NoteForDesinger";
            public const string BackDesignPlacement = "BackDesignPlacement";
            public const string FrontDesignPlacement = "FrontDesignPlacement";
            public const string OrderStatus = "OrderStatus";
            public const string LastStoreId = "LastStoreId";


            public const string Title = "Title";
            public const string ProductiontimeImage = "ProductiontimeImage";
            public const string ProductiontimeXGarmentId = "ProductiontimeXGarmentId";
            public const string Summary = "Summary";
            public const string ShipingInDays = "ShipingInDays";
            public const string AdditionalCharges = "AdditionalCharges";
            public const string DefaultGarmentColorId = "DefaultGarmentColorId";
            public const string DefaultGarmentColorName = "DefaultGarmentColorName";
            public const string PrintPersonalizationType = "PrintPersonalizationType";
            public const string PointToRedeem = "PointToRedeem";
            public const string AmountToRedeem = "AmountToRedeem";
            public const string OrderType = "OrderType";
            /*Resource related Db Columns*/
            public const string ResourceKey = "ResourceKey";
            public const string ResourceValue = "ResourceValue";
            public const string CultureName = "CultureName";

            /*Db Columns Related to Conversation*/
            public const string CommentText = "CommentText";
            public const string ToUserId = "ToUserId";
            public const string FromUserId = "FromUserId";
            public const string IsArtWorkApproved = "IsArtWorkApproved";
            public const string ArtWorkStatus = "ArtWorkStatus";
            public const string IsMessageUnread = "IsMessageUnread";
            public const string IsCategoryHomePageTemplate = "IsCategoryHomePageTemplate";
            public const string OrderInvoiceNo = "OrderInvoiceNo";
            public const string AdminPurchaseOrderNo = "AdminPurchaseOrderNo";
            public const string ConversationFileName = "ConversationFileName";

            public const string ProblemType = "ProblemType";
            public const string SchoolName = "SchoolName";
            public const string TicketSubject = "TicketSubject";
            public const string ProblemId = "ProblemId";
            public const string CreatedBy = "CreatedBy";

            /*Db Columns Related to Brand*/
            public const string BrandName = "BrandName";
            public const string BrandId = "BrandId";
            public const string BrandColorId = "BrandColorId";
            public const string CategoryName = "CategoryName";

            /*Db Columns Related to Garment Color Images*/
            public const string GarmentColorId = "GarmentColorId";
            public const string BackImage = "BackImage";
            public const string FrontImage = "FrontImage";
            public const string SideImage = "SideImage";
            public const string ModelImage = "ModelImage";
            public const string YouthModelImage = "YouthModelImage";            
            public const string IsDefault = "IsDefault";

            /*Db Columns Related to Broucher Images*/
            public const string BroucherImage = "BroucherImage";
            public const string BroucherUrl = "BroucherUrl";

            /*Db Columns Related to SW District*/
            public const string DistrictId = "DistrictId";
            public const string StateCode = "StateCode";
            public const string RegionId = "RegionId";
            public const string SchoolTypeId = "SchoolTypeId";
            public const string DistrictName = "DistrictName";
            public const string DistrictAddress = "DistrictAddress";
            public const string DistrictCity = "DistrictCity";
            public const string DistrictZip = "DistrictZip";
            public const string BuyerName = "BuyerName";
            public const string BuyerEmail = "BuyerEmail";
            public const string BuyerPhone = "BuyerPhone";
            public const string DistrictStatus = "DistrictStatus";
            public const string Vendor = "Vendor";
            public const string CustomerNotes = "CustomerNotes";
            public const string RegDate = "RegDate";
            public const string IsEnabled = "IsEnabled";
            public const string IsDeleted = "IsDeleted";
            public const string BuyerFax = "BuyerFax";

            /*Db Columns Related to Order ArtWork*/
            public const string ArtWorkNo = "ArtWorkNo";
            public const string ArtWorkFileName = "ArtWorkFileName";
            public const string ConversationId = "ConversationId";
            public const string Hours = "Hours";
            public const string PassedHrs = "PassedHrs";
            public const string OrderInvoiceFile = "OrderInvoiceFile";
            public const string InvoiceStatus = "InvoiceStatus";
            public const string NoOfInvoices = "NoOfInvoices";
            public const string OrderArtWorkId = "OrderArtWorkId";
            public const string RefOrderArtWorkId = "RefOrderArtWorkId";
            public const string RefOrderInvoiceId = "RefOrderInvoiceId";
            public const string IsDeleteArtwork = "IsDeleteArtwork";
            public const string IsDeleteInvoice = "IsDeleteInvoice";
            public const string CanceledDate = "CanceledDate";



            /*Db Columns Related to Store*/
            public const string StoreName = "StoreName";
            public const string TitleId = "TitleId";
            public const string StoreCode = "StoreCode";
            public const string StoreDescription = "StoreDescription";
            public const string StoreColor = "StoreColor";
            public const string Organization = "Organization";
            public const string PhoneNo = "PhoneNo";
            public const string IsEmailShow = "IsEmailShow";
            public const string CheckPayableTo = "CheckPayableTo";
            public const string MailingAddress = "MailingAddress";
            public const string DeliveryDetail = "DeliveryDetail";
            public const string GradeLevelLabelName = "GradeLevelLabelName";
            public const string OpenDate = "OpenDate";
            public const string CloseDate = "CloseDate";
            public const string ProfitEmailDate = "ProfitEmailDate";
            public const string IsStoreApproved = "IsStoreApproved";
            public const string IsFinalSubmitByOwner = "IsFinalSubmitByOwner";
            public const string ApprovedDate = "ApprovedDate";
            public const string StoreStatus = "StoreStatus";
            public const string StatusUpdatedDate = "StatusUpdatedDate";
            public const string IsReviewed = "IsReviewed";
            public const string CountStoreGarment = "CountStoreGarment";
            public const string DeliveryDate = "DeliveryDate";
            public const string IsFundraising = "IsFundraising";
            public const string FundAmount = "FundAmount";
            public const string CountSubmitedContactInfo = "CountSubmitedContactInfo";
            public const string CountSubmitedStoreDetails = "CountSubmitedStoreDetails";
            public const string IsSortingStarted = "IsSortingStarted";
            public const string TaxAplicable = "TaxAplicable";
            public const string IsRetired = "IsRetired";
            public const string GroupName = "GroupName";
            public const string IsOrderForm = "IsOrderForm";
            public const string ProfitCheckAmount = "ProfitCheckAmount";
            public const string GroupId = "GroupId";
            public const string HeaderName = "HeaderName";
            public const string HeaderId = "HeaderId";
            public const string SelectedHeaderName = "SelectedHeaderName";
            public const string SelectedHeaderId = "SelectedHeaderId";
            public const string IsGlobalPromoApplied = "IsGlobalPromoApplied";
            public const string IsFSDone = "IsFSDone";



            public const string IsSorted = "IsSorted";
            public const string SortedPrice = "SortedPrice";
            public const string StoreProfiltAmt = "StoreProfiltAmt";
            public const string GradeId = "GradeId";
            public const string TeacherName = "TeacherName";
            public const string PlanType = "PlanType";
            public const string TeacherId = "TeacherId";
            public const string IsTeacherUsed = "IsTeacherUsed";


            public const string FundraisingItemQty = "FundraisingItemQty";
            public const string FundraisingDesc = "FundraisingDesc";
            public const string FullName = "FullName";
            public const string StoreOrderId = "StoreOrderId";
            public const string CreditCardNo = "CreditCardNo";
            public const string CardType = "CardType";
            public const string ZipCode = "ZipCode";
            public const string StoreId = "StoreId";
            public const string StoreDesignId = "StoreDesignId";
            public const string EstimatedOrderQty = "EstimatedOrderQty";
            public const string SWPrice = "SWPrice";
            public const string StorePrice = "StorePrice";
            public const string ApproveOrderArtWork = "ApproveOrderArtWork";
            public const string StoreGarmentColorId = "StoreGarmentColorId";
            public const string ImageDisplayType = "ImageDisplayType";
            public const string ImageName = "ImageName";
            public const string DisplayType = "DisplayType";
            public const string Display = "Display";
            public const string SendEmail = "SendEmail";
            public const string StoreUserId = "StoreUserId";
            public const string IsMerge = "IsMerge";
            public const string IsSendProfitEmail = "IsSendProfitEmail";
            public const string IsSelected = "IsSelected";
            public const string IsOptional = "IsOptional";
            public const string TotalDesignInStore = "TotalDesignInStore";
            public const string TotalGroupOrder = "TotalGroupOrder";
            public const string StoreNubmber = "StoreNubmber";
            public const string GroupOrderTaxAmount = "GroupOrderTaxAmount";
            public const string GroupOrderQuantity = "GroupOrderQuantity";
            public const string PrintColors = "PrintColors";






            public const string OtherTitle = "OtherTitle";
            public const string Level1BasePrice = "Level1BasePrice";
            public const string Level2BasePrice = "Level2BasePrice";
            public const string Level3BasePrice = "Level3BasePrice";
            public const string Level4BasePrice = "Level4BasePrice";
            public const string BasePriceMarkUp = "BasePriceMarkUp";
            public const string RoundUpValue = "RoundUpValue";
            public const string MarkUpPercent = "MarkUpPercent";
            public const string GradeName = "GradeName";
            public const string GradeLevelId = "GradeLevelId";


            public const string EmailContent = "EmailContent";
            public const string SubjectName = "SubjectName";
            public const string TemplateType = "TemplateType";
            public const string MessageBoardText = "MessageBoardText";

            public const string ArtworkId = "ArtworkId";
            public const string Front = "Front";
            public const string Back = "Back";
            public const string DecorationId = "DecorationId";
            public const string Location3Name = "Location3Name";
            public const string Location3 = "Location3";
            public const string Location4Name = "Location4Name";
            public const string Location4 = "Location4";
            public const string HeatPress = "HeatPress";

            public const string DeliveryType = "DeliveryType";
            public const string DeliveredBy = "DeliveredBy";
            public const string FedexTrakingNo = "FedexTrakingNo";
            public const string CompletionDate = "CompletionDate";
            public const string OrderStatusUpdatedDate = "OrderStatusUpdatedDate";

            public const string Message = "Message";
            public const string SMSMessage = "SMSMessage";
            public const string FAQMessage = "FAQMessage";
            public const string ScheduleCompletionDate = "ScheduleCompletionDate";
            public const string ParentOrderId = "ParentOrderId";
            public const string GarmentSuggestionId = "GarmentSuggestionId";
            public const string AdditionalPricePerItem = "AdditionalPricePerItem";
            public const string PricePerItemWithAdditionalPrice = "PricePerItemWithAdditionalPrice";
            public const string LineItemPriceAfterDiscount = "LineItemPriceAfterDiscount";
            public const string AdditionalSizePrices = "AdditionalSizePrices";
            public const string AdditionalSizePriceAfterDiscount = "AdditionalSizePriceAfterDiscount";

            public const string ReOrderId = "ReOrderId";
            public const string SortPrice = "SortPrice";

            public const string MessageVideoType = "MessageVideoType";
            public const string MessageType = "MessageType";
            public const string EmojiImage = "EmojiImage";
            public const string VideoType = "VideoType";
            public const string VideoToolTip = "VideoToolTip";
            public const string VideoUrl = "VideoUrl";

            /*Db Columns Related to AccountCategory*/

            public const string AccountType = "AccountType";
            public const string IsFreeGift = "IsFreeGift";
            public const string OrderValue = "OrderValue";
            public const string OrderNo = "OrderNo";
            public const string MinGarment = "MinGarment";
            public const string MaxGarment = "MaxGarment";
            public const string FreeGarment = "FreeGarment";
            public const string IsUserPromo = "IsUserPromo";

            public const string StateName = "StateName";
            public const string IsOther = "IsOther";
            public const string SchoolTypeName = "SchoolTypeName";

            public const string CampusName = "CampusName";
            public const string PhoneNumberType = "PhoneNumberType";
            public const string SchoolCampusId = "SchoolCampusId";
            public const string StateId = "StateId";
            public const string SchoolDistrict = "SchoolDistrict";
            public const string ApprovedVendor = "ApprovedVendor";

            public const string IsTaxExempt = "IsTaxExempt";
            public const string TaxExempt = "TaxExempt";
            public const string RoleId = "RoleId";
            
            public const string IsOtherCampus = "IsOtherCampus";
            public const string IsOtherCategoryName = "IsOtherCategoryName";
            public const string IsOtherState = "IsOtherState";
            public const string IsOtherSchoolType = "IsOtherSchoolType";
            public const string FreeGiftDesign = "FreeGiftDesign";
            public const string FreeGiftQty = "FreeGiftQty";
            public const string FreeGiftAvailableQty = "FreeGiftAvailableQty";
            public const string PurchaseOrderFile = "PurchaseOrderFile";
            public const string IsSchoolDistrictExempt = "IsSchoolDistrictExempt";
            public const string IsActiveCategory = "IsActiveCategory";
            public const string CellPhone = "CellPhone";
            public const string IsNotifications = "IsNotifications";


            /*Db Columns Related to Financial Statement*/
            public const string CreditCardFees = "CreditCardFees";
            public const string Design1Invoice = "Design1Invoice";
            public const string Design2Invoice = "Design2Invoice";
            public const string Design1InvoiceAmount = "Design1InvoiceAmount";
            public const string Design2InvoiceAmount = "Design2InvoiceAmount";
            public const string EstimatedProfit = "EstimatedProfit";
            public const string Design1TotalAmount = "Design1TotalAmount";
            public const string Design2TotalAmount = "Design2TotalAmount";
            public const string OnlineSalesProfit = "OnlineSalesProfit";
            public const string OnlineTotalAmount = "OnlineTotalAmount";
            public const string OnlineTotalQty = "OnlineTotalQty";
            public const string OrderFormTotalAmount = "OrderFormTotalAmount";
            public const string OrderFormTotalQuantity = "OrderFormTotalQuantity";
            public const string OtherCreditAmount1 = "OtherCreditAmount1";
            public const string OtherCreditAmount2 = "OtherCreditAmount2";
            public const string OtherCreditAmount3 = "OtherCreditAmount3";
            public const string OtherCreditDescriptions1 = "OtherCreditDescriptions1";
            public const string OtherCreditDescriptions2 = "OtherCreditDescriptions2";
            public const string OtherCreditDescriptions3 = "OtherCreditDescriptions3";
            public const string OtherDeductionAmount1 = "OtherDeductionAmount1";
            public const string OtherDeductionAmount2 = "OtherDeductionAmount2";
            public const string OtherDeductionAmount3 = "OtherDeductionAmount3";
            public const string OtherDeductionDescriptions1 = "OtherDeductionDescriptions1";
            public const string OtherDeductionDescriptions2 = "OtherDeductionDescriptions2";
            public const string OtherDeductionDescriptions3 = "OtherDeductionDescriptions3";
            public const string RefundFees = "RefundFees";
            public const string SortFees = "SortFees";
            public const string TotalTaxAmount = "TotalTaxAmount";
            public const string DesignNo1 = "DesignNo1";
            public const string DesignNo2 = "DesignNo2";


        }
    }//end class
}//end namespace
