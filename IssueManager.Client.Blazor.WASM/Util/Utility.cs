namespace IssueManager.Client.Blazor.WASM.Util
{
    public static class Utility
    {
        public static string GetStatusColor(string status)
        {
            if (status == null)
            {
                return "";
            }
            if (status.Equals("open"))
            {
                return "bg-yellow-500 font-semibold";
            }
            else if (status.Equals("assigned"))
            {
                return "bg-green-500 font-semibold";
            }
            else if (status.Equals("closed"))
            {
                return "bg-red-500 font-semibold";
            }
            return "";

        }
    }
}