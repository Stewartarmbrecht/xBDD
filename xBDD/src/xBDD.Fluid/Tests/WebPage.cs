using System;

namespace xBDD.Fluid
{
    public class WebPage : IWebPage
    {
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Title
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IWebPage Click(string buttonName)
        {
            throw new NotImplementedException();
        }

        public string GetFieldText(string fieldName)
        {
            throw new NotImplementedException();
        }

        public IWebPage NavigateTo()
        {
            throw new NotImplementedException();
        }

        public void UpdateField(string fieldName, string fieldValue)
        {
            throw new NotImplementedException();
        }
    }
}