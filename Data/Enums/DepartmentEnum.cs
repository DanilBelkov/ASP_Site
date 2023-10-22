using System.ComponentModel;

namespace MotivTest.Data.Enums
{
    public enum DepartmentEnum
    {
        [Description("Офис обслуживания")]
        ServiceOffice = 1,
        [Description("Контакт-Центр")]
        ContactCenter
    }

    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null) return null;

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length == 0) return null;

            return ((DescriptionAttribute)attributes[0]).Description;
        }
       
    }
}
