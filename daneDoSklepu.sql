SET IDENTITY_INSERT [dbo].[Colors] ON
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (1, N'Biały')
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (2, N'Czarny')
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (3, N'Srebrny')
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (4, N'Złoty')
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (5, N'Niebieski')
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (6, N'Czerwony')
INSERT INTO [dbo].[Colors] ([Id], [Name]) VALUES (7, N'Drewniany')
SET IDENTITY_INSERT [dbo].[Colors] OFF

SET IDENTITY_INSERT [dbo].[Countries] ON
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Polska')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (2, N'Niemcy')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (3, N'USA')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (4, N'Rosja')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (5, N'Japonia')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (6, N'Chiny')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (7, N'Szwajcaria')
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (8, N'Taiwan')
SET IDENTITY_INSERT [dbo].[Countries] OFF

SET IDENTITY_INSERT [dbo].[DeliveryStates] ON
INSERT INTO [dbo].[DeliveryStates] ([Id], [Name]) VALUES (1, N'Przyjęto w bazie')
INSERT INTO [dbo].[DeliveryStates] ([Id], [Name]) VALUES (2, N'Kompletowanie zamówienia')
INSERT INTO [dbo].[DeliveryStates] ([Id], [Name]) VALUES (3, N'Przeznaczono do wysyłki')
INSERT INTO [dbo].[DeliveryStates] ([Id], [Name]) VALUES (4, N'Wysłano')
INSERT INTO [dbo].[DeliveryStates] ([Id], [Name]) VALUES (5, N'Odebrano')
SET IDENTITY_INSERT [dbo].[DeliveryStates] OFF

SET IDENTITY_INSERT [dbo].[DeliveryTypes] ON
INSERT INTO [dbo].[DeliveryTypes] ([Id], [Name]) VALUES (1, N'Kurier DHL')
INSERT INTO [dbo].[DeliveryTypes] ([Id], [Name]) VALUES (2, N'Poczta Polska')
INSERT INTO [dbo].[DeliveryTypes] ([Id], [Name]) VALUES (3, N'Gołębiem')
INSERT INTO [dbo].[DeliveryTypes] ([Id], [Name]) VALUES (4, N'Odbiór osobity')
SET IDENTITY_INSERT [dbo].[DeliveryTypes] OFF

SET IDENTITY_INSERT [dbo].[DiscountCodes] ON
INSERT INTO [dbo].[DiscountCodes] ([DiscountCodeId], [Code], [Discount], [ValidUntil]) VALUES (1, N'zadarmo', 100, N'2021-11-26 00:00:00')
INSERT INTO [dbo].[DiscountCodes] ([DiscountCodeId], [Code], [Discount], [ValidUntil]) VALUES (2, N'półdarmo', 50, N'2021-11-29 00:00:00')
INSERT INTO [dbo].[DiscountCodes] ([DiscountCodeId], [Code], [Discount], [ValidUntil]) VALUES (3, N'dejno5złotych', 1, N'2022-11-30 00:00:00')
SET IDENTITY_INSERT [dbo].[DiscountCodes] OFF

SET IDENTITY_INSERT [dbo].[Kategorias] ON
INSERT INTO [dbo].[Kategorias] ([Id], [Name]) VALUES (1, N'Myszki')
INSERT INTO [dbo].[Kategorias] ([Id], [Name]) VALUES (2, N'Klawiatury')
INSERT INTO [dbo].[Kategorias] ([Id], [Name]) VALUES (3, N'Słuchawki')
INSERT INTO [dbo].[Kategorias] ([Id], [Name]) VALUES (4, N'Gry')
INSERT INTO [dbo].[Kategorias] ([Id], [Name]) VALUES (5, N'Kontrolery')
INSERT INTO [dbo].[Kategorias] ([Id], [Name]) VALUES (6, N'Podkładki')
SET IDENTITY_INSERT [dbo].[Kategorias] OFF

SET IDENTITY_INSERT [dbo].[PaymentTypes] ON
INSERT INTO [dbo].[PaymentTypes] ([Id], [Name]) VALUES (1, N'Przelew')
INSERT INTO [dbo].[PaymentTypes] ([Id], [Name]) VALUES (2, N'Paysafecard')
INSERT INTO [dbo].[PaymentTypes] ([Id], [Name]) VALUES (3, N'BLIK')
INSERT INTO [dbo].[PaymentTypes] ([Id], [Name]) VALUES (4, N'Ziemniakami (na tony)')
INSERT INTO [dbo].[PaymentTypes] ([Id], [Name]) VALUES (5, N'Bitcoin')
INSERT INTO [dbo].[PaymentTypes] ([Id], [Name]) VALUES (6, N'Skinami do CSGO')
SET IDENTITY_INSERT [dbo].[PaymentTypes] OFF

SET IDENTITY_INSERT [dbo].[Producents] ON
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (1, N'Corsair', 3)
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (2, N'Logitech', 7)
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (3, N'HyperX', 3)
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (4, N'A4Tech', 8)
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (5, N'Microsoft', 3)
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (6, N'Razer', 3)
INSERT INTO [dbo].[Producents] ([Id], [Name], [Country_Id]) VALUES (7, N'Sony', 5)
SET IDENTITY_INSERT [dbo].[Producents] OFF

SET IDENTITY_INSERT [dbo].[SwitchTypes] ON
INSERT INTO [dbo].[SwitchTypes] ([Id], [Name]) VALUES (1, N'Membranowa')
INSERT INTO [dbo].[SwitchTypes] ([Id], [Name]) VALUES (2, N'Mechaniczna - czerwone')
INSERT INTO [dbo].[SwitchTypes] ([Id], [Name]) VALUES (3, N'Mechaniczna - niebieskie')
INSERT INTO [dbo].[SwitchTypes] ([Id], [Name]) VALUES (4, N'Mechaniczna - brązowe')
INSERT INTO [dbo].[SwitchTypes] ([Id], [Name]) VALUES (5, N'Mechaniczna - srebrne')
INSERT INTO [dbo].[SwitchTypes] ([Id], [Name]) VALUES (6, N'Mechaniczna - białe')
SET IDENTITY_INSERT [dbo].[SwitchTypes] OFF

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (3, 2, N'G502 Hero', N'2021-11-29 00:00:00', 1, N'Mysz została wyposażona w nowy sensor <i>Hero</i>, z możliwością rozgrywki na poziomie nawet <b>25600 DPI</b>! G502 dysponuje wbudowaną pamięcią, dzięki której zapisane ustawienia weźmiesz ze sobą <span style="color:red"><b>wszędzie</b></span>!', 1, 25600, 11, NULL, 2, 0, CAST(249.99 AS Decimal(18, 2)), 2, 1, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (5, 6, N'DeathAdder V2 Pro', N'2020-09-22 00:00:00', 1, N'Myszka bezprzewodowa wyposażona jest w ulepszony czujnik 20 000 DPI. Razer Hyperspeed sprawia, że myszka jest szybsza o 25% niż inna dostępna technologia bezprzewodowa i ma najmniejsze opóźnienie kliknięcia.', 1, 20000, 8, NULL, 2, 0, CAST(663.65 AS Decimal(18, 2)), 2, 1, 6, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (6, 2, N'G102 Lightsync', N'2020-05-01 00:00:00', 1, N'Mysz wyposażona jest w technologię LIGHTSYNC, czujnik przeznaczony do gier oraz klasyczną 6-przyciskową konstrukcję. Zaprogramuj swoje własne podświetlenie spośród około 16,8 miliona kolorów.', 1, 8000, 6, NULL, 2, 0, CAST(107.00 AS Decimal(18, 2)), 2, 1, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (7, 6, N'Mamba Elite', N'2018-08-01 00:00:00', 1, N'Mamba Elite posiada doceniany przez graczy sensor Razer 5G oraz cenione przełączniki mechaniczne. Ponadto gracz otrzymuje możliwość pełnej kontroli dzięki 9 programowalnym przyciskom oraz pełną wygodę dzięki ulepszonej, ergonomicznej konstrukcji.', 1, 16000, 9, NULL, 2, 0, CAST(251.00 AS Decimal(18, 2)), 2, 1, 6, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (8, 4, N'X-748k', N'2014-08-01 00:00:00', 1, N'Mysz A4Tech z serii XGame, wyposażona w 7 przycisków, sensor V-track, ultra szybkie złącze USB oraz szereg dodatkowych atutów, stworzonych specjalnie z myślą o graczach i grafikach komputerowych. Dodatkowy przycisk 3XFire umożliwia oddanie trzykrotnego strzału w czasie gry zaledwie jednym naciśnięciem klawisza. Zmieniający kolor przełącznik rozdzielczości 5DPI (od 400 do 2000 DPI) umożliwia zwiększanie lub zmniejszanie czułości myszy bez potrzeby instalowania dodatkowego sterownika i wpływa bezpośrednio na szybkość i precyzję działania. Wyjątkową cechą wyróżniającą to urządzenie są specjalnie zaprojektowane wyjmowane ciężarki, dostosowujące wagę myszki do potrzeb graczy.', 0, 2000, 7, NULL, 2, 0, CAST(82.78 AS Decimal(18, 2)), 2, 1, 4, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (9, 2, N'G Pro Wireless', N'2020-12-03 00:00:00', 1, N'PRO Wireless to wyjątkowa mysz go grania dla profesjonalnych e-sportowców. Przez ponad 2 lata dział Logitech G współpracował z ponad 50 profesjonalnymi graczami, aby móc zagwarantować idealny kształt, masę i odczucia połączone z technologią bezprzewodową LIGHTSPEED i czujnikiem HERO. Wynikiem tego jest mysz do grania o niezrównanej wydajności i precyzji, zapewniająca narzędzia i pewność siebie, aby zwyciężać.', 1, 25600, 8, NULL, 2, 1, CAST(479.00 AS Decimal(18, 2)), 2, 1, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (10, 7, N'Playstation 5 DualSense Biały', N'2021-06-18 00:00:00', 5, N'Kultowy gamepad od Sony w nowej wersji. Ulepszony kształt, świetnie wpasuje się do dłoni, a innowacyjne efekty dotykowe, wzniosą rozgrywkę na znacznie wyższy i realistyczniejszy poziom.', 0, 0, 14, NULL, 1, 1, CAST(299.00 AS Decimal(18, 2)), 1, 5, 7, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (11, 5, N'Xbox One Gameplad', N'2013-11-22 00:00:00', 5, N'Z przewodowym kontrolerem Xbox dla systemu Windows jeszcze bardziej zaangażujesz się w grę. Zyskaj większą wygodę podczas gry dzięki kontrolerowi Xbox o bardziej opływowym kształcie i chropowatej teksturze uchwytów. Podłącz kontroler do komputera za pomocą kabla USB i korzystaj z doprowadzenia zasilania,niewymagającego baterii. Kontroler Xbox z przewodem dla systemu Windows może być używany przewodowo lub bezprzewodowo z konsolą Xbox One.', 0, 0, 13, NULL, 2, 1, CAST(388.68 AS Decimal(18, 2)), 2, 5, 5, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (12, 2, N'Hard Gaming G440', N'2014-09-01 00:00:00', 6, N'Szybkie i nagłe ruchy, zatrzymania i zmiany w kierunku to nie problem, jeśli masz podkładkę G440. Gumowe podłoże utrzymuje podkładkę w miejscu podczas intensywnego grania.', 0, 0, 0, NULL, 2, 1, CAST(117.00 AS Decimal(18, 2)), 2, 6, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (13, 4, N'XGame X7-500MP L', N'2014-08-01 00:00:00', 6, N'Duże rozmiary, a także wysokiej jakości materiał sprawiają, że jest to bardzo dobra materiałowa podkładka zapewniająca komfort poślizgu myszy.', 0, 0, 0, NULL, 2, 1, CAST(27.90 AS Decimal(18, 2)), 2, 6, 4, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (14, 6, N'Gigantus', N'2020-05-26 00:00:00', 6, N'Podkładka stworzona z myślą o graczach, którzy nie mogą sobie pozwolić na ograniczenie i opóźnienia związane z małym rozmiarem podkładki. Powierzchania podkładki została zoptymalizowana dla wysokiej jakości śledzenia, dając zwiększoną precyzję ', 0, 0, 0, NULL, 2, 1, CAST(111.09 AS Decimal(18, 2)), 2, 6, 6, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (15, 2, N'G733 Lightspeed Black', N'2020-09-01 00:00:00', 3, N'G733 jest bezprzewodowy i stworzony dla komfortu. Jest on wyposażony w dźwięk przestrzenny, filtry głosowe i zaawansowane oświetlenie, których potrzebujesz, aby wyglądać, brzmieć i grać bardziej stylowo niż kiedykolwiek.', 1, 0, 0, NULL, 2, 1, CAST(549.00 AS Decimal(18, 2)), 2, 3, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (16, 1, N'HS60 Pro Surround', N'2021-03-18 00:00:00', 3, N'Wysokiej jakości, dostrojone 50 mm neodymowe sterowniki audio zapewniają zasięg, aby słyszeć wszystko, czego potrzebujesz na polu bitwy, a w pełni odłączany jednokierunkowy mikrofon redukuje hałas otoczenia.', 0, 0, 0, NULL, 2, 0, CAST(265.99 AS Decimal(18, 2)), 2, 3, 1, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (17, 2, N'G PRO X Gaming Headset', N'2020-08-01 00:00:00', 3, N'Wbudowany mikrofon BLUE VO!CE daje możliwość redukcji szumów, dodania kompresji i usuwania syczenia oraz gwarantuje bogatszy, czystszy i brzmiący bardziej profesjonalnie głos.', 0, 0, 0, NULL, 2, 0, CAST(419.00 AS Decimal(18, 2)), 2, 3, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (18, 3, N'Cloud Alpha S', N'2020-03-01 00:00:00', 3, N'Kultowy model Cloud Alpha doczekał się udoskonalenia! Specjalny dźwięk przestrzenny HyperX 7.1 oraz wyjątkowy komfort to tylko nieliczne zalety tych słuchawek.', 0, 0, 0, NULL, 2, 0, CAST(489.00 AS Decimal(18, 2)), 2, 3, 3, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (19, 1, N'K70 RGB MK.2 Low-Profile', N'2018-10-25 00:00:00', 2, N'Nowa, smukła, lekka konstrukcja klawiatury i trwała aluminiowa rama klasy lotniczej, zbudowana tak, aby wytrzymać dożywotnią rozgrywkę przy wysokości zaledwie 29 mm.', 1, 0, 113, 5, 2, 0, CAST(649.00 AS Decimal(18, 2)), 2, 2, 1, 5)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (20, 6, N'Huntsman Mini Red Switch', N'2020-07-14 00:00:00', 2, N'Klawiatura idealna do minimalistycznych lub mniejszych konfiguracji, w których miejsce na biurku jest premium, jego kompaktowa budowa oznacza również, że jest lżejsza do ustawienia podczas gry - co pozwala na wygodniejszą grę.', 1, 0, 61, 2, 1, 0, CAST(499.00 AS Decimal(18, 2)), 1, 2, 6, 2)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (21, 2, N'G413 Carbon', N'2017-04-01 00:00:00', 2, N'Klawiatura jest wyposażona w mechaniczne przełączniki Romer-G i oferuje przypisanie makr do 12-tu klawiszy funkcyjnych. W zestawie znajduje się 12 dodatkowych nakładek na klawisze.', 0, 0, 104, 6, 2, 0, CAST(289.00 AS Decimal(18, 2)), 2, 2, 2, 6)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (22, 2, N'G213 Prodigy', N'2016-09-01 00:00:00', 2, N'Logitech G213 ma specjalne klawisze z podświetleniem RGB, które reagują nawet 4x szybciej w porównaniu do standardowych klawiatur. Konstrukcja jest wytrzymała, precyzyjna i odporna na zalanie.', 1, 0, 113, 1, 2, 0, CAST(239.00 AS Decimal(18, 2)), 2, 2, 2, 1)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (23, 3, N'Alloy Core RGB', N'2018-11-01 00:00:00', 2, N'Klawiaturę HyperX Alloy Core RGB™ charakteryzuje oryginalny podświetlany pasek HyperX oraz płynne i dynamiczne efekty świetlne RGB. Jest to idealne rozwiązanie dla graczy, którzy nie chcą rozbijać banku, a poszukują klawiatury oferującej doskonały styl i możliwości. Ta ekonomiczna klawiatura oferuje sześć efektów świetlnych i trzy poziomy jasności. Alloy Core RGB to solidna konstrukcja ze wzmocnionego plastiku charakteryzująca się stabilnością i niezawodnością. Spełni więc potrzeby graczy poszukujących wytrzymałej klawiatury.', 1, 0, 114, 1, 2, 0, CAST(219.00 AS Decimal(18, 2)), 2, 2, 3, 1)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (24, 1, N'K95 RGB Platinum', N'2017-01-01 00:00:00', 2, N'Interfejs USB

Łączność Przewodowa

Przełączniki mechaniczne - Cherry MX Speed
Obsługa makr
Podpórka pod nadgarstki', 1, 0, 119, 5, 2, 0, CAST(719.00 AS Decimal(18, 2)), 2, 2, 1, 5)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (25, 3, N'Alloy Origins CORE', N'2021-02-22 00:00:00', 2, N'HyperX Alloy Origins™ Core to trwała, ultra-kompaktowa klawiatura ze specjalnymi przełącznikami mechanicznymi HyperX, stworzona by zapewnić graczom idealne połączenie stylu, wygody i niezawodności. Przełączniki klawiszy podświetlane przez widoczne diody LED charakteryzuje wyważenie siły aktywacji i skoku. W ten sposób uzyskano szybką reakcję i dokładność.', 1, 0, 87, 2, 2, 0, CAST(389.00 AS Decimal(18, 2)), 2, 2, 3, 2)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (26, 2, N'G502 Wireless', N'2021-11-27 00:00:00', 0, N'Bezprzewodowy wariant myszy Logitech G502', 1, 25600, 11, NULL, 2, 1, CAST(420.00 AS Decimal(18, 2)), 2, 1, 2, NULL)
INSERT INTO [dbo].[Products] ([Id], [Producent_Id], [Name], [ReleaseDate], [Kategoria_Id], [Description], [CzyRGB], [MaxDPI], [ButtonCount], [SwitchType_Id], [Color_Id], [IsWireless], [Cena], [Color_Id1], [Kategoria_Id1], [Producent_Id1], [SwitchType_Id1]) VALUES (31, 3, N'Clout Epic Gamer', N'2021-11-27 18:20:42', 3, N'UWAGA! Oferta <b>NIE DLA KAŻDEGO</b>! <h1>ELITARNE SŁUCHAWKI DLA ELITARNYCH GRACZY</h1> ZŁOTO CZYSTE JAK SKILL KARTOMKA!', 1, NULL, NULL, NULL, 4, 0, CAST(999.99 AS Decimal(18, 2)), 4, 3, 3, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[Zamówienie] ON
INSERT INTO [dbo].[Zamówienie] ([OrderId], [Username], [FirstName], [LastName], [Address], [City], [PostalCode], [Country], [Phone], [Email], [Total], [OrderDate], [deliveryTypeId], [paymentTypeId], [DeliveryStateId]) VALUES (1, N'matix273@gmail.com', N'xd', N'xd', N'ul. XD-Project 21', N'Wadowice', N'34-100', N'Polska', N'123456789', N'matix273@gmail.com', CAST(999.99 AS Decimal(18, 2)), N'2021-11-27 18:21:33', 1, 5, 1)
INSERT INTO [dbo].[Zamówienie] ([OrderId], [Username], [FirstName], [LastName], [Address], [City], [PostalCode], [Country], [Phone], [Email], [Total], [OrderDate], [deliveryTypeId], [paymentTypeId], [DeliveryStateId]) VALUES (2, N'matix273@gmail.com', N'xd', N'xd', N'ul. XD-Project 21', N'Wadowice', N'34-100', N'Polska', N'123456789', N'matix273@gmail.com', CAST(499.99 AS Decimal(18, 2)), N'2021-11-27 18:24:05', 2, 1, 1)
INSERT INTO [dbo].[Zamówienie] ([OrderId], [Username], [FirstName], [LastName], [Address], [City], [PostalCode], [Country], [Phone], [Email], [Total], [OrderDate], [deliveryTypeId], [paymentTypeId], [DeliveryStateId]) VALUES (3, N'matix273@gmail.com', N'xd', N'xd', N'ul. XD-Project 21', N'Wadowice', N'34-100', N'Polska', N'123456789', N'matix273@gmail.com', CAST(657.01 AS Decimal(18, 2)), N'2021-11-29 13:23:03', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Zamówienie] OFF
