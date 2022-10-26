using psteg.Algorithm;
using psteg.Algorithm.Crypto;
using psteg.Algorithm.Stegano;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psteg {
    public static class EngineInitializer {
        private static bool _init = false;

        public static Dictionary<CryptoMethod, Type> UnconditionalCrypto = new Dictionary<CryptoMethod, Type>
        {
            { CryptoMethod.Rijndael, typeof(CryptoRijndael) }
        };

        private static Dictionary<StegMethod, Type> UnconditionalSteg = new Dictionary<StegMethod, Type>
        {
            { StegMethod.LSB, typeof(SteganoLSB) }
        };

        private static Dictionary<StegMethod, Type> MonoLockedSteg = new Dictionary<StegMethod, Type>
        {
            { StegMethod.ADS, typeof(SteganoADS) }
        };



        private static void MonoDisabledMethods() {
            if (Type.GetType("Mono.Runtime") == null) {
                foreach (KeyValuePair<StegMethod, Type> kv in MonoLockedSteg)
                    PstegEngine.KnownSteg.Add(kv.Key, kv.Value);
            }
        }

        private static void AddUnconditionalMethods() {
            foreach (KeyValuePair<StegMethod, Type> kv in UnconditionalSteg) 
                PstegEngine.KnownSteg.Add(kv.Key, kv.Value);
            foreach (KeyValuePair<CryptoMethod, Type> kv in UnconditionalCrypto)
                PstegEngine.KnownCrypto.Add(kv.Key, kv.Value);
        }

        public static void Initialize() {
            if (_init)
                return;

            PstegEngine.KnownSteg = new Dictionary<StegMethod, Type>();
            PstegEngine.KnownCrypto = new Dictionary<CryptoMethod, Type>();

            //add methods disabled for mono
            MonoDisabledMethods();

            //add methods locked to bouncycastle


            //add rest unconditionally
            AddUnconditionalMethods();

            _init = true;
        }
    }
}
