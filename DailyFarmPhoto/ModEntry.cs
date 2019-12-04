using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Text;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using System.IO;

namespace DailyFarmPhoto
{
    class ModEntry : Mod
    {
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.TimeChanged += this.OnTimeChanged;
        }
        
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnTimeChanged(object sender, TimeChangedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (e.NewTime != 620)
                return;

            var configResolution = 25;
            
            Game1.game1.takeMapScreenshot((float)configResolution / 100f, Game1.player.Name + "_" + Game1.Date.TotalDays + "_" + Game1.Date.Season + "_" + Game1.Date.DayOfMonth + "_" + Game1.timeOfDay);

            // print button presses to the console window
            this.Monitor.Log($"Hit 630", LogLevel.Debug);
        }
    }
}
