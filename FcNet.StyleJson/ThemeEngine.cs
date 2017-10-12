using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
            if (string.IsNullOrWhiteSpace(prop) || string.IsNullOrWhiteSpace(val)) return;

            string[] sVal = val.Split(';');
            string[] sProp = prop.Split('.');
            string iProp = prop.Contains(".") ? sProp[1] : prop;
            object obj = ctr;

            PropertyInfo pInfo = ctr.GetType().GetProperty(sProp[0]);

            if (sProp[0] == "FlatAppearance")
            {
                obj = (ctr as Button).FlatAppearance;
                pInfo = obj.GetType().GetProperty(sProp[1]);
            }
            else if (sProp[0] == "TabItemAppearance") { }

            if (pInfo == null) return;

            string bTypeName = pInfo.PropertyType.BaseType.Name;
            string pType = (bTypeName == "Enum" ? bTypeName : pInfo.PropertyType.Name);

            switch (pType)
            {
                case "Enum":
                    pInfo.SetValue(obj, Enum.Parse(pInfo.PropertyType, val));
                    break;
                case "Color":
                    pInfo.SetValue(obj, GetColor(val));
                    break;
                case "Int32":
                    pInfo.SetValue(obj, Int32.Parse(val));
                    break;
                case "BorderSize":
                    pInfo.SetValue(obj, Int32.Parse(val));
                    break;
                case "Font":
                    ctr.Font = new Font(sVal[0], Utils.GetInt(sVal[1]), (FontStyle)(Utils.GetInt(sVal[2]) | Utils.GetInt(sVal[3])));
                    break;
                case "BackgroundImage":
                    ctr.BackgroundImage = Image.FromFile(val);
                    break;
                case "Size":
                    ctr.Size = new Size(Utils.GetInt(sVal[0]), Utils.GetInt(sVal[1]));
                    break;
                case "Padding":
                    ctr.Padding = new Padding(Utils.GetInt(sVal[0]), Utils.GetInt(sVal[1]), Utils.GetInt(sVal[2]), Utils.GetInt(sVal[3]));
                    break;
                default:
                    break;
            }
        }

        private static void ApplyThemeToControl2(Control ctr, string prop, string val)
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
                case "MouseOverBackColor":
                case "MouseDownBackColor":
                case "CheckedBackColor":
                case "CheckedMouseDownBackColor":
                case "CheckedMouseOverBackColor":
                case "CheckedForeColor":
                case "CheckedMouseOverForeColor":
                case "CheckedBorderColor":
                    if (pi != null) pi.SetValue(ctr, GetColor(val));
                    break;
                case "CheckedBorderSize":
                    if (pi != null) pi.SetValue(ctr, int.Parse(val));
                    break;
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
