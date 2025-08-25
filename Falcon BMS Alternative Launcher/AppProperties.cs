using System.Windows;

using FalconBMS.Launcher.Windows;

namespace FalconBMS.Launcher
{
    public class AppProperties
    {
        private MainWindow mainWindow;
        public int bandWidthDefault = 1024;

        public AppProperties(MainWindow mainWindow)
        {
            Diagnostics.Log("Start Reading Launcher Settings.");

            this.mainWindow = mainWindow;

            // Load Buttons
            mainWindow.CMD_ACMI.IsChecked                  = Properties.Settings.Default.CMD_ACMI;
            mainWindow.CMD_WINDOW.IsChecked                = Properties.Settings.Default.CMD_WINDOW;
            mainWindow.CMD_NOMOVIE.IsChecked               = Properties.Settings.Default.CMD_NOMOVIE;
            mainWindow.CMD_EF.IsChecked                    = Properties.Settings.Default.CMD_EF;
            mainWindow.CMD_MONO.IsChecked                  = Properties.Settings.Default.CMD_MONO;
            bandWidthDefault                               = Properties.Settings.Default.CMD_BW;
            mainWindow.ApplicationOverride.IsChecked       = Properties.Settings.Default.NoOverride;
            mainWindow.Misc_RollLinkedNWS.IsChecked        = Properties.Settings.Default.Misc_RLNWS;
            mainWindow.Misc_TrackIRZ.IsChecked             = Properties.Settings.Default.Misc_TrackIRZ;
            mainWindow.Misc_ExMouseLook.IsChecked          = Properties.Settings.Default.Misc_ExMouseLook;
            mainWindow.Misc_SmartScalingOverride.IsChecked = Properties.Settings.Default.Misc_SmartScalingOverride;
            mainWindow.Misc_NaturalHeadMovement.IsChecked  = Properties.Settings.Default.Misc_NaturalHeadMovement;
            mainWindow.Misc_PilotModel.IsChecked           = Properties.Settings.Default.Misc_PilotModel;
            mainWindow.Misc_bRingCommMenu.IsChecked        = Properties.Settings.Default.Misc_bRingCommMenu;
            mainWindow.Misc_bMFDHighContrast.IsChecked     = Properties.Settings.Default.Misc_bMFDHighContrast;
            mainWindow.Misc_bExportRTTTextures.IsChecked   = Properties.Settings.Default.Misc_bExportRTTTextures;
            mainWindow.Misc_bReducePSFires.IsChecked       = Properties.Settings.Default.Misc_bReducePSFires;
            mainWindow.Misc_nNewTerrainHiresTilesDistKM.IsChecked = Properties.Settings.Default.Misc_nNewTerrainHiresTilesDistKM;

            // fRadarScale
            double savedScale = Properties.Settings.Default.Misc_fRadarScale;
            string savedTag = savedScale.ToString(System.Globalization.CultureInfo.InvariantCulture);
            mainWindow.Misc_fRadarScale.SelectedValuePath = "Tag";
            mainWindow.Misc_fRadarScale.SelectedValue = savedTag;
            // Fallback if the list changed or nothing matched
            if (mainWindow.Misc_fRadarScale.SelectedValue == null)
                mainWindow.Misc_fRadarScale.SelectedValue = "1";

            // fCursorSpeed
            double savedCursor = Properties.Settings.Default.Misc_fCursorSpeed;
            string savedCursorTag = savedCursor.ToString(System.Globalization.CultureInfo.InvariantCulture);
            mainWindow.Misc_fCursorSpeed.SelectedValuePath = "Tag";
            mainWindow.Misc_fCursorSpeed.SelectedValue = savedCursorTag;
            // Fallback if the list changed or nothing matched
            if (mainWindow.Misc_fCursorSpeed.SelectedValue == null)
                mainWindow.Misc_fCursorSpeed.SelectedValue = "1";

            // Button Status Default
            if (Properties.Settings.Default.VR_Option == "SteamVR")
            {
                mainWindow.VR_NoVR.IsChecked = false;
                mainWindow.VR_SteamVR.IsChecked = true;
                mainWindow.VR_OpenXR.IsChecked = false;
            }
            else
            if (Properties.Settings.Default.VR_Option == "OpenXR")
            {
                mainWindow.VR_NoVR.IsChecked = false;
                mainWindow.VR_SteamVR.IsChecked = false;
                mainWindow.VR_OpenXR.IsChecked = true;
            }
            else
            {
                mainWindow.VR_NoVR.IsChecked = true;
                mainWindow.VR_SteamVR.IsChecked = false;
                mainWindow.VR_OpenXR.IsChecked = false;
            }
            mainWindow.CMD_BW.Content               = "BW : " + bandWidthDefault;
            mainWindow.AB_Throttle.Visibility       = Visibility.Hidden;
            mainWindow.AB_Throttle_Right.Visibility = Visibility.Hidden;

            Diagnostics.Log("Finished Reading Launcher Settings.");
        }

        public void SaveUISetup()
        {
            Properties.Settings.Default.CMD_ACMI                  = (bool)mainWindow.CMD_ACMI.IsChecked;
            Properties.Settings.Default.CMD_WINDOW                = (bool)mainWindow.CMD_WINDOW.IsChecked;
            Properties.Settings.Default.CMD_NOMOVIE               = (bool)mainWindow.CMD_NOMOVIE.IsChecked;
            Properties.Settings.Default.CMD_EF                    = (bool)mainWindow.CMD_EF.IsChecked;
            Properties.Settings.Default.CMD_MONO                  = (bool)mainWindow.CMD_MONO.IsChecked;
            Properties.Settings.Default.CMD_BW                    = bandWidthDefault;
            Properties.Settings.Default.NoOverride                = (bool)mainWindow.ApplicationOverride.IsChecked;
            Properties.Settings.Default.Misc_RLNWS                = (bool)mainWindow.Misc_RollLinkedNWS.IsChecked;
            Properties.Settings.Default.Misc_TrackIRZ             = (bool)mainWindow.Misc_TrackIRZ.IsChecked;
            Properties.Settings.Default.Misc_ExMouseLook          = (bool)mainWindow.Misc_ExMouseLook.IsChecked;
            Properties.Settings.Default.Misc_SmartScalingOverride = (bool)mainWindow.Misc_SmartScalingOverride.IsChecked;
            Properties.Settings.Default.Misc_NaturalHeadMovement  = (bool)mainWindow.Misc_NaturalHeadMovement.IsChecked;
            Properties.Settings.Default.Misc_PilotModel           = (bool)mainWindow.Misc_PilotModel.IsChecked;
            Properties.Settings.Default.VR_Option = (bool)mainWindow.VR_SteamVR.IsChecked ? "SteamVR" : (bool)mainWindow.VR_OpenXR.IsChecked ? "OpenXR" : "NoVR";
            Properties.Settings.Default.Misc_bRingCommMenu = (bool)mainWindow.Misc_bRingCommMenu.IsChecked;
            Properties.Settings.Default.Misc_bMFDHighContrast = (bool)mainWindow.Misc_bMFDHighContrast.IsChecked;
            Properties.Settings.Default.Misc_bExportRTTTextures = (bool)mainWindow.Misc_bExportRTTTextures.IsChecked;
            Properties.Settings.Default.Misc_bReducePSFires = (bool)mainWindow.Misc_bReducePSFires.IsChecked;
            Properties.Settings.Default.Misc_nNewTerrainHiresTilesDistKM = (bool)mainWindow.Misc_nNewTerrainHiresTilesDistKM.IsChecked;

            double radarScale = 1.0;
            if (mainWindow.Misc_fRadarScale?.SelectedValue is string sel &&
                double.TryParse(sel, System.Globalization.NumberStyles.Float,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out var parsed))
            {
                radarScale = parsed;
            }
            Properties.Settings.Default.Misc_fRadarScale = radarScale;

            double cursorSpeed = 1.0;
            if (mainWindow.Misc_fCursorSpeed?.SelectedValue is string selCursor &&
                double.TryParse(selCursor, System.Globalization.NumberStyles.Float,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out var parsedCursor))
            {
                cursorSpeed = parsedCursor;
            }
            Properties.Settings.Default.Misc_fCursorSpeed = cursorSpeed;

            Properties.Settings.Default.Save();
        }

        public void CMD_BW_Click()
        {
            bandWidthDefault *= 2;
            if (bandWidthDefault > 10000)
            {
                bandWidthDefault = 512;
            }
            mainWindow.CMD_BW.Content = "BW : " + bandWidthDefault;
        }
    }
}
