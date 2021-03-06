/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace OfficeOpenXml.Style.Dxf
{
    /// <summary>
    /// A single border line of a drawing in a differential formatting record
    /// </summary>
    public class ExcelDxfBorderItem : DxfStyleBase<ExcelDxfBorderItem>
    {
        internal ExcelDxfBorderItem(ExcelStyles styles) :
            base(styles)
        {
            Color=new ExcelDxfColor(styles);
        }
        /// <summary>
        /// The border style
        /// </summary>
        public ExcelBorderStyle? Style { get; set;}
        /// <summary>
        /// The color of the border
        /// </summary>
        public ExcelDxfColor Color { get; internal set; }

        /// <summary>
        /// The Id
        /// </summary>
        protected internal override string Id
        {
            get
            {
                return GetAsString(Style) + "|" + (Color == null ? "" : Color.Id);
            }
        }

        /// <summary>
        /// Creates the the xml node
        /// </summary>
        /// <param name="helper">The xml helper</param>
        /// <param name="path">The X Path</param>
        protected internal override void CreateNodes(XmlHelper helper, string path)
        {            
            SetValueEnum(helper, path + "/@style", Style);
            SetValueColor(helper, path + "/d:color", Color);
        }
        /// <summary>
        /// If the object has a value
        /// </summary>
        protected internal override bool HasValue
        {
            get 
            {
                return Style != null || Color.HasValue;
            }
        }
        /// <summary>
        /// Clone the object
        /// </summary>
        /// <returns>A new instance of the object</returns>
        protected internal override ExcelDxfBorderItem Clone()
        {
            return new ExcelDxfBorderItem(_styles) { Style = Style, Color = Color };
        }
    }
}
