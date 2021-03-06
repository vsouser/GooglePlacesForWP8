﻿using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Places.Resources;
using GooglePlacesApi;
using Places.ViewModel;

namespace Places
{
    public partial class App : Application
    {
        /// <summary>
        /// Обеспечивает быстрый доступ к корневому кадру приложения телефона.
        /// </summary>
        /// <returns>Корневой кадр приложения телефона.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        public static MainPanoramaViewModel MainPanoramaViewModel { get; set; }
        public static NetworkErrorViewModel NetworkErrorViewModel { get; set; }
        public static ResultPageViewModel ResultPageViewModel { get; set; }
        public static BaseSearchViewModel NerbySearchViewModel { get; set; }
        public static GeoLocationErrorViewModel GeoLocationErrorViewModel { get; set; }
        public static ApiErrorViewModel ApiErrorViewModel { get; set; }

        public static PlaceInfoSearchViewModel PlaceInfoSearchViewModel { get; set; }
        public static PlaceInfoViewModel PlaceInfoViewModel { get; set; }

        public static Place SelectPlace { get; set; }
        public static LanguageController LanguageController { get; set; }
        public static GoogleApiKeyTable GoogleApiKeyTable { get; set; }
        public static GeoLocationController GeoLocationController { get; set; }
        public static TypesController TypesContoller { get; set; }


        /// <summary>
        /// Конструктор объекта приложения.
        /// </summary>
        public App()
        {
            // Глобальный обработчик неперехваченных исключений.
            UnhandledException += Application_UnhandledException;

            // Стандартная инициализация XAML
            InitializeComponent();

            // Инициализация телефона
            InitializePhoneApplication();

            // Инициализация отображения языка
            InitializeLanguage();

            // Отображение сведений о профиле графики во время отладки.
            if (Debugger.IsAttached)
            {
                // Отображение текущих счетчиков частоты смены кадров.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Отображение областей приложения, перерисовываемых в каждом кадре.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Включение режима визуализации анализа нерабочего кода,
                // для отображения областей страницы, переданных в GPU, с цветным наложением.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Предотвратить выключение экрана в режиме отладчика путем отключения
                // определения состояния простоя приложения.
                // Внимание! Используйте только в режиме отладки. Приложение, в котором отключено обнаружение бездействия пользователя, будет продолжать работать
                // и потреблять энергию батареи, когда телефон не будет использоваться.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Код для выполнения при запуске приложения (например, из меню "Пуск")
        // Этот код не будет выполняться при повторной активации приложения
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            LanguageController = new LanguageController();
            //GoogleApiKeyTable = new GoogleApiKeyTable("AIzaSyCmlHiWshBC77iFO8lJp5VqLjZurbSDcXU", "AIzaSyCRuDl06RN51s-rzbICyjagZERWSKRpep4", "AIzaSyAhMx9QEuodwotkLM0MrH-j5_7aHFEgZDo", "AIzaSyD_SAiM0LqhMn0MzJ56KvrdKm1eROoqTM4", "AIzaSyAYQdeRFOz8Vin_pzdmg2ZAr0HjDUyiTO8", "AIzaSyBQF-Q8B0iIXeTwk-wp6H2TGXPeDORbR68", "AIzaSyB8amnrPgm0zuL2mOyLF19ZL8nGuWAA57o", "AIzaSyDHJjNda8MIhJiaFvAMbgEQxh3pbFzagrQ", "AIzaSyCwN04nDu7I6OsPnJMe99o94zEEYR4Ho08", "AIzaSyDS5k4-IHhynoWd02ZyPeowzGo-_1mi_y8", "AIzaSyC5RsOTNTWW73tfNM39gi02IIueIYQD_4Q", "AIzaSyAWP94Hnu3KAk08bOeWwm0qwrw29y4T4qw", "AIzaSyBBwSZVydnnjfVGj5qSEysU8mgA9whbCCQ", "AIzaSyDImAt3enFymi3YBwTJNvr1D_Y3Jdwm1HQ", "AIzaSyDbfC9ZThpnWq98TchyIXgtHY7_ZhpFUg8", "AIzaSyA9NROw6JfbQtLCrP62XJVKZMj0DwIIioQ", "AIzaSyAGdvWCn-CuwQKpqmJ_P7Rz-2U-ffHNo5U", "AIzaSyAXQVXvu6r-bXmVGhKVj4d4OJUJPzdoyds", "AIzaSyAQ9-5JBbZIkpnXHUkK9FNA-wG72GPB6eo", "AIzaSyCSLSwu74EReRwyHrg1gcpL4MvALlTAs0M");
            GoogleApiKeyTable = new GooglePlacesApi.GoogleApiKeyTable("AIzaSyCq8jBh1ieYwG6hioyXRsaiBAr2uAZlA_I");
            TypesContoller = new TypesController(LanguageController.GetGooglePlacesLanguage());
            TypesContoller.Instance();

            TypesContoller.Types.Sort();
            App.MainPanoramaViewModel = new MainPanoramaViewModel(TypesContoller.Require, TypesContoller.Types);
            App.NetworkErrorViewModel = new NetworkErrorViewModel();
            App.GeoLocationErrorViewModel = new GeoLocationErrorViewModel();
            App.ApiErrorViewModel = new ApiErrorViewModel();
        }

        // Код для выполнения при активации приложения (переводится в основной режим)
        // Этот код не будет выполняться при первом запуске приложения
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Код для выполнения при деактивации приложения (отправляется в фоновый режим)
        // Этот код не будет выполняться при закрытии приложения
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Код для выполнения при закрытии приложения (например, при нажатии пользователем кнопки "Назад")
        // Этот код не будет выполняться при деактивации приложения
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Код для выполнения в случае ошибки навигации
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // Ошибка навигации; перейти в отладчик
                Debugger.Break();
            }
        }

        // Код для выполнения на необработанных исключениях
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // Произошло необработанное исключение; перейти в отладчик
                Debugger.Break();
            }
        }

        #region Инициализация приложения телефона

        // Избегайте двойной инициализации
        private bool phoneApplicationInitialized = false;

        // Не добавляйте в этот метод дополнительный код
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Создайте кадр, но не задавайте для него значение RootVisual; это позволит
            // экрану-заставке оставаться активным, пока приложение не будет готово для визуализации.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Обработка сбоев навигации
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Обработка запросов на сброс для очистки стека переходов назад
            RootFrame.Navigated += CheckForResetNavigation;

            // Убедитесь, что инициализация не выполняется повторно
            phoneApplicationInitialized = true;
        }

        // Не добавляйте в этот метод дополнительный код
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Задайте корневой визуальный элемент для визуализации приложения
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Удалите этот обработчик, т.к. он больше не нужен
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // Если приложение получило навигацию "reset", необходимо проверить
            // при следующей навигации, чтобы проверить, нужно ли выполнять сброс стека
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Отменить регистрацию события, чтобы оно больше не вызывалось
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Очистка стека только для "новых" навигаций (вперед) и навигаций "обновления"
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // Очистка всего стека страницы для согласованности пользовательского интерфейса
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // ничего не делать
            }
        }

        #endregion

        // Инициализация шрифта приложения и направления текста, как определено в локализованных строках ресурсов.
        //
        // Чтобы убедиться, что шрифт приложения соответствует поддерживаемым языкам, а
        // FlowDirection для каждого из этих языков соответствует традиционному направлению, ResourceLanguage
        // и ResourceFlowDirection необходимо инициализировать в каждом RESX-файле, чтобы эти значения совпадали с
        // культурой файла. Пример:
        //
        // AppResources.es-ES.resx
        //    Значение ResourceLanguage должно равняться "es-ES"
        //    Значение ResourceFlowDirection должно равняться "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     Значение ResourceLanguage должно равняться "ar-SA"
        //     Значение ResourceFlowDirection должно равняться "RightToLeft"
        //
        // Дополнительные сведения о локализации приложений Windows Phone см. на странице http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
        {
            try
            {
                // Задать шрифт в соответствии с отображаемым языком, определенным
                // строкой ресурса ResourceLanguage для каждого поддерживаемого языка.
                //
                // Откат к шрифту нейтрального языка, если отображаемый
                // язык телефона не поддерживается.
                //
                // Если возникла ошибка компилятора, ResourceLanguage отсутствует в
                // файл ресурсов.
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Установка FlowDirection для всех элементов в корневом кадре на основании
                // строки ресурса ResourceFlowDirection для каждого
                // поддерживаемого языка.
                //
                // Если возникла ошибка компилятора, ResourceFlowDirection отсутствует в
                // файл ресурсов.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                // Если здесь перехвачено исключение, вероятнее всего это означает, что
                // для ResourceLangauge неправильно задан код поддерживаемого языка
                // или для ResourceFlowDirection задано значение, отличное от LeftToRight
                // или RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}