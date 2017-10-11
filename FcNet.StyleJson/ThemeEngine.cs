using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FcNet.FormStyleJson
{
    public static class ThemeEngine
    {
        private static string _themePath;
        private static JObject _jObject;
        private static IEnumerable<Control> _controls;

        public static void ApplyTheme(Control mainContainer, string themePath = @".\Themes\Default\theme.json")
        {
            _themePath = themePath;
            _controls = GetAllControls(mainContainer);
            GetJson();
            SetControlTheme();
            SetElementTheme();
        }

        private static void GetJson()
        {
            using (var json = new StreamReader(_themePath))
            {
                _jObject = JObject.Load(new JsonTextReader(json));
            }
        }

        public static void SetControlTheme()
        {
            foreach (var ctr in _controls)
            {
                JToken obj = (from r in _jObject.ToObject<Dictionary<string, JToken>>()
                              where r.Key.Contains(ctr.GetType().Name)
                              select r.Value).FirstOrDefault();

                if (obj != null) SetProperty(ctr, obj);
            }
        }

        public static void SetElementTheme()
        {
            foreach (var ctr in _controls)
            {
                JToken obj = (from r in _jObject.ToObject<Dictionary<string, JToken>>()
                              where r.Key.Contains(ctr.Name)
                              select r.Value).FirstOrDefault();

                if (obj != null) SetProperty(ctr, obj);
            }
        }

        private static void SetProperty(Control ctr, JToken token)
        {
            foreach (JProperty prop in token.ToList())
            {
                ApplyThemeToControl(ctr, prop.Name.ToString(), prop.Value.ToString());
            }
        }

        private static void ApplyThemeToControl(Control ctr, string prop, string val)
        {
            PropertyInfo pi = ctr.GetType().GetProperty(prop);

            if (pi == null || string.IsNullOrWhiteSpace(val))
            {
                if (prop != "FlatAppearance" || prop != "TabAppearance")
                {
                    return;
                }
            }

            string[] splitVal = val.Contains(";") ? val.Split(';') : null;

            switch (prop)
            {
                // FlatAppearance Properties
                case "BorderSize":
                    if (ctr is Button) (ctr as Button).FlatAppearance.BorderSize = (val == "" ? 0 : int.Parse(val));
                    break;
                case "BorderColor":
                    if (ctr is Button) (ctr as Button).FlatAppearance.BorderColor = GetColor(val);
                    break;
                case "MouseOverBackColor":
                    if (ctr is Button) (ctr as Button).FlatAppearance.MouseOverBackColor = GetColor(val);
                    break;
                case "MouseDownBackColor":
                    if (ctr is Button) (ctr as Button).FlatAppearance.MouseDownBackColor = GetColor(val);
                    break;
                case "CheckedBackColor":
                    if (ctr is Button) (ctr as Button).FlatAppearance.CheckedBackColor = GetColor(val);
                    break;

                //case "CheckedMouseDownBackColor":
                //    if (ctr is Button) (ctr as Button).FlatAppearance.MouseDownBackColor = GetColor(val); 
                //    break;
                //case "CheckedMouseOverBackColor":
                //    if (ctr is Button) (ctr as Button).FlatAppearance.MouseOverBackColor = GetColor(val);
                //    break;
                //case "CheckedForeColor":
                //    if (ctr is Button) (ctr as Button).FlatAppearance.MouseDownBackColor = (val == "Transparent" ? Color.Transparent : ColorFromHtml(val));
                //    break;
                //case "CheckedMouseOverForeColor":
                //    if (ctr is Button) (ctr as Button).FlatAppearance.MouseDownBackColor = (val == "Transparent" ? Color.Transparent : ColorFromHtml(val));
                //    break;
                //case "CheckedBorderColor":
                //    if (ctr is Button) (ctr as Button).FlatAppearance.MouseDownBackColor = (val == "Transparent" ? Color.Transparent : ColorFromHtml(val));
                //    break;
                //case "CheckedBorderSize":
                //    if (ctr is Button) (ctr as Button).FlatAppearance.BorderSize = (val == "" ? 0 : int.Parse(val));
                //    break;

                // End FlatAppearance Properties

                case "BackColor":
                    ctr.BackColor = ColorFromHtml(val);
                    break;
                case "ForeColor":
                    ctr.ForeColor = ColorFromHtml(val);
                    break;
                case "Font":
                    ctr.Font = new Font(splitVal[0], Utils.GetInt(splitVal[1]), (FontStyle)(Utils.GetInt(splitVal[2]) | Utils.GetInt(splitVal[3])));
                    break;
                case "BackgroundImage":
                    ctr.BackgroundImage = Image.FromFile(val);
                    break;
                case "BackgroundImageLayout":
                    ctr.BackgroundImageLayout = val.ToEnum<ImageLayout>();
                    break;
                case "BorderStyle":
                    if (pi != null) pi.SetValue(ctr, val.ToEnum<BorderStyle>());
                    break;
                case "FlatStyle":
                    if (pi != null) pi.SetValue(ctr, val.ToEnum<FlatStyle>());
                    break;
                case "Size":
                    ctr.Size = new Size(Utils.GetInt(splitVal[0]), Utils.GetInt(splitVal[1]));
                    break;
                case "Padding":
                    ctr.Padding = new Padding(Utils.GetInt(splitVal[0]), Utils.GetInt(splitVal[1]), Utils.GetInt(splitVal[2]), Utils.GetInt(splitVal[3]));
                    break;
                case "Dock":
                    ctr.Dock = val.ToEnum<DockStyle>();
                    break;
                default:
                    break;
            }
        }

        private static IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = container.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }

        private static Color ColorFromHtml(string value)
        {
            return ColorTranslator.FromHtml(value);
        }

        private static Color GetColor(string value)
        {
            return (value == "Transparent" ? Color.Transparent : ColorFromHtml(value));
        }
    }
}
