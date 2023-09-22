namespace Ecommerce_BE.Messages
{
    public class BusinessMessage
    {
        //NOT_FOUND
        public const string NotFoundProduct = "Sản phẩm không tồn tại";
        public const string NotFoundIngredient= "Nguyên liệu không tồn tại";
        public const string NotFoundImportBill = "Hóa đơn nhập hàng khôn tồn tại";
        public const string NotFoundSaleOfBill = "Hóa đơn bán hàng không tồn tại";

        //NULL
        public const string IngredientNameRequied = "Tên nguyên liệu không được trống";
        public const string IngredientPriceRequied = "Giá nguyên liệu phải lớn hơn 0";
        public const string IngredientWeightRequied = "Trọng lượng nguyên liệu phải lớn hơn 0 ";

        // CREATE PRODUCT

        public const string IngredientNotExist = "Một hoặc nhiều nguyên liệu bạn chọn không tồn tại";
        public const string ProductNotExist = "Một hoặc nhiều sản phẩm bạn chọn không tồn tại";
        public const string BillOfSaleNotExist = "Hóa đơn không tồn tại";

    }
}
