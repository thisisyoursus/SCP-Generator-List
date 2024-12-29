using System;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Generator_List_for_SCPs
{
    public class Config:IConfig
    {
        [Description("Decide whether you want to enable the plugin or not.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Decide whether you want to enable debugging or not.")]
        public bool Debug {  get; set; }=true;
        [Description("Sets the color of the displayed list. Default is 'Orange'.")]
        public string Color { get; set; } = "orange";
        [Description("Sets size of the list. Default is 18.")]
        public int Size { get; set; } = 18;
        [Description("Sets vertical position of the list. Default is 960. (very top)")]
        public int Vertical { get; set; } = 960;
        [Description("Sets horizontal positon of the list. (left or right) Default is left.")]
        public string Horizontal { get; set; } = "left";
    }
}
