        static void decodeIndexes()
        {
            byte []indexes  = {
                250,
				242,
				240,
				235,
				243,
				249,
				247,
				245,
				238,
				232,
				253,
				244,
				237,
				251,
				234,
				233,
				236,
				246,
				241,
				255,
				252
            };

            List<string> resolved = new List<string>();
            for (var i = 0; i < indexes.Length; i++)
            {
                var val = indexes[i] ^ 248;
                //make IP
                string str = val.ToString();
                byte[] a = Encoding.ASCII.GetBytes(str);
                string lenIP = String.Format("199.0.0.{0}", str.Length + 1);
                resolved.Add(lenIP);

                string valIP = "";
                if (str.Length > 1)
                {
                    valIP = String.Format("43.{0}.{1}.0", a[0], a[1]);
                } else
                {
                    valIP = String.Format("43.{0}.0.0", a[0]);
                }
                resolved.Add(valIP);
            }

            for (var i = 0; i < resolved.Count; i++)
            {
                //Console.WriteLine("DomainsList.Add(\"{0}\");", resolved[i]);
                Console.WriteLine("{0}", resolved[i]);
            }
        }
		