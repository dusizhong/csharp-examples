using System.Xml.Linq;

namespace HebcaBidder
{
    static class GlobalStore
    {
        private static XElement tenderInfo;
        private static XElement tenderForm;
        private static XElement bidFile;

        public static XElement TenderInfo
        {
            get { return tenderInfo; }
            set { tenderInfo = value; }
        }

        public static XElement TenderForm
        {
            get { return tenderForm; }
            set { tenderForm = value; }
        }

        public static XElement BidFile
        {
            get { return bidFile; }
            set { bidFile = value; }
        }
    }
}
