using MudBlazor;

namespace Ganymede.Theme;

public class GanymedeTheme
{
    public static readonly MudTheme Default = new MudTheme
    {
        // ---- Light Mode (No Light mode for this editor) ----

        // ---- Dark Mode ----
        PaletteDark = new PaletteDark
        {
            Background                  = "#1B1B1B",
            Surface                     = "#242424",
            AppbarBackground            = "#2A2A2A",
            AppbarText                  = "#D4D4D4",
            DrawerBackground            = "#202020",
            DrawerText                  = "#B8B8B8",
            Primary                     = "#5B8DB8",
            PrimaryDarken               = "#4A7599",
            Secondary                   = "#8B8B8B",
            Success                     = "#6A9955",
            Warning                     = "#C9A227",
            Error                       = "#C25450",
            Info                        = "#5B8DB8",
            TextPrimary                 = "#D4D4D4",
            TextSecondary               = "#9A9A9A",
            TextDisabled                = "#5E5E5E",
            Divider                     = "#333333",
            DividerLight                = "#2C2C2C",
            LinesDefault                = "#333333",
            LinesInputs                 = "#3D3D3D",
            TableLines                  = "#2C2C2C",
            ActionDefault               = "#9A9A9A",
            ActionDisabled              = "#5E5E5E",
            ActionDisabledBackground    = "#2A2A2A",

            HoverOpacity                = 0.06
        },

        Typography = new Typography 
        {
            Default = new DefaultTypography
            {
                FontFamily  = ["Inter", "Segoe UI", "Roboto", "sans-serif"],
                FontSize    = "0.8125rem",
                LineHeight  = "1.4",
            },

            Button = new ButtonTypography
            {
                FontSize        = "0.8125rem",
                TextTransform   = "none",
                FontWeight      = "500"
            },

            Body2 = new Body2Typography
            {
                FontSize = "0.75rem"
            }
        },

        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "3px",
            DrawerWidthLeft     = "280px",
            DrawerWidthRight    = "300px",
            AppbarHeight        = "48px"
        },

        Shadows = new Shadow()
    };
}

