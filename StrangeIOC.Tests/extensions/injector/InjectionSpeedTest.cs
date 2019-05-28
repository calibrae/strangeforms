/**
 * Technically this is not a unit test. Rather, it's a
 * development tool to rate the value of the Reflector extension.
 *
 * This scenario measured 64ms with the ReflectionBinder, 302ms without.
 */

using System.Diagnostics;
using NUnit.Framework;
using strange.extensions.injector.api;
using strange.extensions.injector.impl;

namespace strange.unittests
{
    [TestFixture]
    public class InjectionSpeedTest
    {
        [Test]
        public void TestALotOfInstances()
        {
            IInjectionBinder injectionBinder = new InjectionBinder();
            injectionBinder.Bind<ClassToBeInjected>().To<ClassToBeInjected>();
            injectionBinder.Bind<int>().To(42);
            injectionBinder.Bind<InjectableSuperClass>().To<InjectableDerivedClass>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var aa = 1000;
            for (var a = 0; a < aa; a++)
            {
                injectionBinder.GetInstance<InjectableSuperClass>();
            }

            stopwatch.Stop();

            //Uncomment this if you want to run the speed test.
            //throw new InjectionException ("The test took " + stopwatch.ElapsedMilliseconds + " ms.", InjectionExceptionType.NO_REFLECTOR);
        }
    }
}