#if FIVEMusing CitizenFX.Core;using CitizenFX.Core.Native;using System.Collections.Generic;using System.Threading.Tasks;using Script = CitizenFX.Core.BaseScript;#elif SHVDN3using GTA;using System.Windows.Forms;#endifusing LemonUI.Menus;namespace LeMi.Client;/// <summary>/// The main menu of LeMi./// </summary>public class MenuMain : NativeMenu{    #region Constructors    /// <summary>    /// Creates a new main menu.    /// </summary>    public MenuMain() : base("", "LeMi", "", null)    {            }        #endregion}