﻿using KombajnPDF.Data.Abstract;
using KombajnPDF.Data.Enum;
using KombajnPDF.Interface;
using KombajnPDF.Properties.Translations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    /// <summary>
    /// Provides language-related functionality such as loading, storing,
    /// and applying translations based on the current application language.
    /// </summary>
    public class LanguageService : ILanguageService
    {
        private LanguagesEnum _currentLanguage;

        // Lazy-initialized cache of ResourceManagers for each supported language.
        private readonly Dictionary<LanguagesEnum, ResourceManager> _resourceManagers = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageService"/> class.
        /// Loads the current language setting and initializes translation resources.
        /// </summary>
        public LanguageService()
        {
            LoadCurrentLanguage();
        }

        /// <summary>
        /// Gets the currently active application language.
        /// </summary>
        public LanguagesEnum CurrentLanguage => _currentLanguage;

        /// <summary>
        /// Loads the current language from user settings and applies it.
        /// </summary>
        private void LoadCurrentLanguage()
        {
            var language = GetLanguage();
            SetLanguage(language);
        }

        /// <summary>
        /// Retrieves the saved language setting from application configuration.
        /// Returns a fallback language if the setting is missing or invalid.
        /// </summary>
        /// <returns>The currently selected language, or a default value if not available.</returns>
        public LanguagesEnum GetLanguage()
        {
            if (Enum.TryParse(Properties.Settings.Default.Language, out LanguagesEnum lang))
                return lang;

            return LanguagesEnum.English; // fallback language
        }

        /// <summary>
        /// Sets the current language and saves it to application settings.
        /// </summary>
        /// <param name="language">The language to set.</param>
        public void SetLanguage(LanguagesEnum language)
        {
            _currentLanguage = language;
            Properties.Settings.Default.Language = language.ToString();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Translates a given <see cref="TranslationCodes"/> key to the currently selected language.
        /// </summary>
        /// <param name="translationCode">The translation code enum representing the resource key.</param>
        /// <returns>The translated string, or a fallback if the key is not found.</returns>
        public string Translate(TranslationCodes translationCode)
        {
            if (!_resourceManagers.TryGetValue(_currentLanguage, out var manager))
            {
                string baseName = $"KombajnPDF.Properties.Translations.Strings.{_currentLanguage}";
                manager = new ResourceManager(baseName, typeof(LanguageService).Assembly);
                _resourceManagers[_currentLanguage] = manager;
            }

            string key = translationCode.ToString();
            return manager.GetString(key) ?? $"[{key}]";
        }

        /// <summary>
        /// Recursively translates a control and all its children by using the Tag property as a translation key.
        /// </summary>
        /// <param name="parent">The root control to apply translations to.</param>
        public void TranslateControl(Control parent)
        {
            if (parent.Tag is string code)
                parent.Text = Translate((TranslationCodes)Enum.Parse(typeof(TranslationCodes), code));

            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag is string childCode)
                    ctrl.Text = Translate((TranslationCodes)Enum.Parse(typeof(TranslationCodes), childCode));

                if (ctrl.HasChildren)
                    TranslateControl(ctrl);
            }
        }
    }
}
