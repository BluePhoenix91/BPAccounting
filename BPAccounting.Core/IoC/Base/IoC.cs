using BPAccounting.Data;
using Dna;
using Ninject;

namespace BPAccounting.Core
{
    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager Task => IoC.Get<ITaskManager>();

        /// <summary>
        /// A shortcut to access toe <see cref="IServerDataStore"/> service
        /// </summary>
        public static IServerDataStore ClientDataStore => Framework.Service<IServerDataStore>();

        /// <summary>
        /// A shortcut to access the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// Static member for the draft model
        /// </summary>
        //public static VATDraftModel VDM { get; private set; }

        /// <summary>
        /// Static member for the register model
        /// </summary>
        //public static VATRegModel VRM { get; private set; }

        /// <summary>
        /// Static member for the VAT draft view model 
        /// </summary>
        //public static VATDraftViewModel VDVM { get; private set; }

        /// <summary>
        /// Static member for the VAT view model
        /// </summary>
        //public static VATViewModel VVM { get; private set; }

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all 
        ///       services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();

            // Generate the required instances
            //GenerateInstances();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

        }

        #endregion

        #region Public methods

        /// <summary>
        /// Get's a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        /// <summary>
        /// Basic initialisation to do at startup
        /// </summary>
        //public static void GenerateInstances()
        //{
        //    VRM = new VATRegModel();
        //    VDM = new VATDraftModel();
        //    VDVM = new VATDraftViewModel();
        //    VVM = new VATViewModel();
        //}

        #endregion
    }
}
