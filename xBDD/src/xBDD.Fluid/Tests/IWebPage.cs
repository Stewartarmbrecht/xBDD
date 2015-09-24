namespace xBDD.Fluid
{
    public interface IWebPage
    {
        string Title { get; }
        string Name { get; set; }

        void UpdateField(string fieldName, string fieldValue);
        IWebPage Click(string buttonName);
        string GetFieldText(string fieldName);
        IWebPage NavigateTo();
    }
}