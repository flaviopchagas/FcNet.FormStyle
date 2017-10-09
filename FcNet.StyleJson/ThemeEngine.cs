using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            if (ctr.GetType().GetProperty(prop) == null || string.IsNullOrWhiteSpace(val))
            {
                if (!(ctr is Button)) return;
            }

            string[] splitVal = val.Contains(";") ? val.Split(';') : null;

            switch (prop)
            {
                case "BackColor":
                case "TabBackColor":
                case "TabActiveBackColor":
                    ctr.BackColor = ColorFromHtml(val);
                    break;
                case "ForeColor":
                case "TabForeColor":
                case "TabActiveForeColor":
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
                case "TabBorderStyle":
                    var pi = ctr.GetType().GetProperty(prop);
                    if (pi != null) pi.SetValue(ctr, val.ToEnum<BorderStyle>());
                    break;
                case "Size":
                    ctr.Size = new Size(Utils.GetInt(splitVal[0]), Utils.GetInt(splitVal[1]));
                    break;
                case "Padding":
                case "TabMargin":
                    ctr.Padding = new Padding(Utils.GetInt(splitVal[0]), Utils.GetInt(splitVal[1]), Utils.GetInt(splitVal[2]), Utils.GetInt(splitVal[3]));
                    break;
                case "Dock":
                    ctr.Dock = val.ToEnum<DockStyle>();
                    break;
                case "MouseOverBackColor":
                case "TabMouseOverBackColor":
                case "TabActiveMouseOverBackColor":
                    if (ctr is Button)
                    {
                        if (val == "Transparent")
                            (ctr as Button).FlatAppearance.MouseOverBackColor = Color.Transparent;
                        else
                            (ctr as Button).FlatAppearance.MouseOverBackColor = ColorFromHtml(val);
                    }
                    break;
                case "MouseDownBackColor":
                case "TabMouseDownBackColor":
                case "TabActiveMouseDownBackColor":
                    if (ctr is Button)
                    {
                        if (val == "Transparent")
                            (ctr as Button).FlatAppearance.MouseDownBackColor = Color.Transparent;
                        else
                            (ctr as Button).FlatAppearance.MouseDownBackColor = ColorFromHtml(val);
                    }
                    break;


                default: break;
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
    }
}
