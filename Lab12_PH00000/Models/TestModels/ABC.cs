namespace Lab12_PH00000.Models.TestModels
{
    public partial class Human
    {
        // Partial Class là 1 kỹ thuật lập trình cho phép viết 1 class trên 2 file vật lý khác nhau ( file .cs)
        public string CCCD { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public int Tuoi { get; set; }
        // @model = strong type cho phép trỏ trực tiếp tới các thuộc tính của đối tượng khi được
        // truyền từ controller sang View. Đối tượng ở đây không phải chỉ là mội object mà có thể
        // là 1 list object
        // 1 View chỉ có thể trỏ tới 1 object duy nhất, nên nếu muốn nhiều ta có thể sử dụng thêm
        // viewbag, viewdata, session,...
    }
    public class Animal
    {
        public string Ten { get; set; }
        public int SoChan { get; set; }
    }
}
