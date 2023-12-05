namespace DynamicMenuApp.Data
{
    public class MenuInfo
    {
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public string PageName { get; set; } = string.Empty;
        public string MenuName { get; set; } = string.Empty;
        public string IconName { get; set; } = string.Empty;
    }
}
