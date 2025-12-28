namespace MauiApp1
{
    public class ClassB
    {
        public int id {  get; set; }
        public string name {  get; set; }
        public bool isSelected { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
