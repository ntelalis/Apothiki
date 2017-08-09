-- Script Date: 8/8/2017 5:01 μμ  - ErikEJ.SqlCeScripting version 3.5.2.71
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Proion] (
  [Name] nvarchar(50) NOT NULL
, CONSTRAINT [pk_PName] PRIMARY KEY ([Name])
);
CREATE TABLE [Kouti] (
  [Id] int NOT NULL
, [Location] nvarchar(50) NULL
, CONSTRAINT [pk_KId] PRIMARY KEY ([Id])
);
CREATE TABLE [Sxesi] (
  [KoutiId] int NOT NULL
, [ProionName] nvarchar(50) NOT NULL
, [KoutiLocation] nvarchar(50) NULL
, CONSTRAINT [pk_SId] PRIMARY KEY ([KoutiId],[ProionName])
, FOREIGN KEY ([KoutiId]) REFERENCES [Kouti] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([ProionName]) REFERENCES [Proion] ([Name]) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO [Proion] ([Name]) VALUES (
'1N34A');
INSERT INTO [Proion] ([Name]) VALUES (
'220 ΒΟΛΤ ΓΕΝΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'24 V ΣΕ 12 V ΜΕΤΑΤΡΟΠΕΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'4 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'4N60');
INSERT INTO [Proion] ([Name]) VALUES (
'50ΝΟ6');
INSERT INTO [Proion] ([Name]) VALUES (
'6 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'60Ν06');
INSERT INTO [Proion] ([Name]) VALUES (
'7805');
INSERT INTO [Proion] ([Name]) VALUES (
'7805 ΜΙΚΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'7808');
INSERT INTO [Proion] ([Name]) VALUES (
'7809');
INSERT INTO [Proion] ([Name]) VALUES (
'7812');
INSERT INTO [Proion] ([Name]) VALUES (
'7812 ΜΙΚΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'7815');
INSERT INTO [Proion] ([Name]) VALUES (
'7824');
INSERT INTO [Proion] ([Name]) VALUES (
'7875');
INSERT INTO [Proion] ([Name]) VALUES (
'7905');
INSERT INTO [Proion] ([Name]) VALUES (
'7906');
INSERT INTO [Proion] ([Name]) VALUES (
'7909');
INSERT INTO [Proion] ([Name]) VALUES (
'7912');
INSERT INTO [Proion] ([Name]) VALUES (
'7915');
INSERT INTO [Proion] ([Name]) VALUES (
'7924');
INSERT INTO [Proion] ([Name]) VALUES (
'8 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'AN 7205');
INSERT INTO [Proion] ([Name]) VALUES (
'AUDIO ΣΑΣΙΟΥ ΠΛΑΚΕΤΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'BAZER');
INSERT INTO [Proion] ([Name]) VALUES (
'BUT11A');
INSERT INTO [Proion] ([Name]) VALUES (
'BYV 42E');
INSERT INTO [Proion] ([Name]) VALUES (
'CD+DVD ΓΙΑ LAPTOP');
INSERT INTO [Proion] ([Name]) VALUES (
'CEP 3205');
INSERT INTO [Proion] ([Name]) VALUES (
'CEP 83A3');
INSERT INTO [Proion] ([Name]) VALUES (
'D 2030A');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 1010');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 3205');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 520');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 620');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 630');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 640');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 740');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 840');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF 9540');
INSERT INTO [Proion] ([Name]) VALUES (
'IRF Z46N');
INSERT INTO [Proion] ([Name]) VALUES (
'LED 1W ΑΝΤΑΛΑΚΤΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'LED ΤΑΙΝΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'LED ΤΑΙΝΙΑ 3 ΧΡΩΜΑΤΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'LED ΥΠΕΡΥΘΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'LM 340');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 12V-100VA');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 13.5 X 2');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 18V-2A');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 24V-100VA');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 250-250V/500VA');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 2X12V1.2A');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 2X250V/500mA');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 2Χ20V');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 330-7V');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 50.5V/500mA');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T 600-800-1000V');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T ΔΙΑΜΟΡΦΩΤΗΣ 100W');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T ΔΙΑΜΟΡΦΩΤΗΣ 5W');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T ΔΙΑΜΩΡΦΩΤΗΣ 20W');
INSERT INTO [Proion] ([Name]) VALUES (
'M/T ΠΟΛΛΕΣ ΤΑΣΕΙΣ 2 ΤΕΜ');
INSERT INTO [Proion] ([Name]) VALUES (
'OA91');
INSERT INTO [Proion] ([Name]) VALUES (
'PEDAL ΗΧΟΥ');
INSERT INTO [Proion] ([Name]) VALUES (
'PLL');
INSERT INTO [Proion] ([Name]) VALUES (
'POWER PACK LAPTOP');
INSERT INTO [Proion] ([Name]) VALUES (
'POWER PACK ΔΙΑΦΟΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'POWER PACK ΜΙΚΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'POWER RACK ΜΕΓΑΛΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'RELE ΙΣΧΥΟΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'SKANTI TRP5000.. DIAFΟRA');
INSERT INTO [Proion] ([Name]) VALUES (
'SOAR 4040 ΑΝΤΑΠΤOΡΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'TA 7342P');
INSERT INTO [Proion] ([Name]) VALUES (
'TRANSISTOR RF');
INSERT INTO [Proion] ([Name]) VALUES (
'TUBE');
INSERT INTO [Proion] ([Name]) VALUES (
'TV ΓΙΑ ΚΙΝΗΤΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'UPS ΜΙΚΡΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'XR2206CP');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΕΡΟΦΥΛΛΟΙ ΠΥΚΝΩΤΕΣ ΑΡΕΟΦΥΛΛΟΙ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΙΣΘΗΤΗΡΕΣ ΚΙΝΗΣΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΚΟΥΣΤΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΜΟΡΤΙΣΕΡ ΚΑΡΕΚΛΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΑΜΕΤΑΔΟΤΗΣ WI FI');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΟΞΥΔΟΤΕΣ ΒΙΔΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΤΑΛΑΚΤΙΚΑ ΓΙΑ ΠΟΝΤΙΚΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΤΑΛΛΑΚΤΙΚΑ ΜΙΚΡΟΦΩΝΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΤΑΠΤΟΡΕΣ VGA - DVI');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΤΑΠΤΟΡΕΣ VIDEO');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΤΙΚΕΡΑΥΝΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΝΤΙΠΑΡΑΣΙΤΙΚΑ ΦΙΛΤΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΣΥΡΜΑΤΑ ΠΟΝΤΙΚΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΣΦΑΛΕΙΟΔΙΑΚΟΠΤΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΑΤΣΑΛΙΝΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΒΑΣΕΙΣ 6 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΒΑΣΕΙΣ 8 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΒΑΣΗ  ΣΤΗΡΗΞΗΣ  ΚΑΘΕΤΗ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΒΑΣΗ ΓΙΑ ΚΑΛΩΔΙΟΤΑΙΝΙΑ 16 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΒΑΣΗ ΟΘΟΝΗΣ PHILIPS');
INSERT INTO [Proion] ([Name]) VALUES (
'ΓΑΛΒΑΝΙΖΕ ΚΑΙ ΣΥΡΜΑΤΑ ΓΙΑ ΠΗΝΕΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΓΕΦΥΡΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΓΩΝΙΕΣ ΓΙΑ ΡΑΦΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΔΕΚΤΕΣ GARRISON');
INSERT INTO [Proion] ([Name]) VALUES (
'ΔΕΚΤΕΣ ΥΠΕΡΥΘΡΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΔΙΑΜΩΡΦΩΤΗΣ ΜΙΚΡΟΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΔΙΟΔΟΙ ΓΕΡΜΑΝΙΟΥ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΔΥΑΔΙΚΟΙ ΔΙΑΚΟΠΤΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΕΚΧΥΛΩΤΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΕΛΙΚΑΣ ΑΕΡΟΠΛΑΝΟΥ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΕΝΚΟΡΝΤΕΡ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΕΞΩΤΕΡΙΚΑ ΗΧΕΙΑ CB VHF');
INSERT INTO [Proion] ([Name]) VALUES (
'ΕΞΩΤΕΡΙΚΕΣ ΘΗΚΕΣ ΣΚΛΗΡΩΝ ΔΙΣΚΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΕΡΓΑΣΤΗΡΙΑΚΑ ΟΡΓΑΝΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ηλεκτροβαλβιδα ατμοσιδερου');
INSERT INTO [Proion] ([Name]) VALUES (
'ΗΛΕΚΤΡΟΝΙΚΟ RELE');
INSERT INTO [Proion] ([Name]) VALUES (
'ΗΛΙΑΚΟΣ ΣΥΛΕΚΤΗΣ 12V');
INSERT INTO [Proion] ([Name]) VALUES (
'ΗΧΕΙΑ ΥΠΟΛΟΓΙΣΤΗ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΘΕΡΜΟΚΟΛΛΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΘΕΡΜΟΜΕΤΡΟ ΗΛΕΚΤΡΟΝΙΚΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΘΕΡΜΟΠΙΣΤΟΛΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΘΕΡΜΟΣ ΑΕΡΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΘΕΡΜΟΣΤΑΤΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΘΗΚΗ ΜΙΚΡΟΦΩΝΟΥ AKG');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ EUROPE');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ LAN');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ RF');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ USB');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ VIDEO');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΓΙΑ MONITOR');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΓΙΑ ΠΑΛΜΟΓΡΑΦΟ ΠΡΟΜΠ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΓΙΑ ΠΟΛΥΜΕΤΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΓΙΑ ΤΣΟΚ 50 ΩΜ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΗΧΟΥ ΛΕΠΤΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΗΧΟΥ ΧΟΝΔΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΚΕΡΑΙΑΣ ΤΗΛΕΟΡΑΣΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΤΡΟΦΟΔΟΣΙΑΣ ΥΨΗΛΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΤΡΟΦΟΔΟΣΙΑΣ ΧΑΜΗΛΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑ ΥΠΟΛΟΓΙΣΤΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΑΚΟΙ ΑΝΤΑΠΤΟΡΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΟ ΓΙΑ ΚΕΡΑΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΛΩΔΙΟΤΑΙΝΙΑ 2Χ16 ΠΟΔΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΜΕΡΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΜΕΡΕΣ WEB');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΡΤΕΣ USB');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΡΤΕΣ ΗΧΟΥ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΡΤΕΣ ΟΘΟΝΗΣ DVI');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΡΤΕΣ ΟΘΟΝΗΣ VGA');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΤΑΣΚΕΥΕΣ PCB');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΨΕΣ ΜΙΚΡΟΦΩΝΟΥ ΔΥΝΑΜΙΚΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΑΨΕΣ ΜΙΚΡΟΦΩΝΟΥ ΠΥΚΝΩΤΗΚΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΕΡΑΙΕΣ ΑΣΥΡΜΑΤΩΝ ΔΙΑΦΟΡΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΕΡΑΜΙΚΟΙ ΚΡΥΣΤΑΛΟΙ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΕΦΑΛΕΣ ΠΙ ΚΑΠ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΛΕΙΔΑΡΙΕΣ ΑΣΦΑΛΕΙΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΛΕΙΔΑΡΙΕΣ ΚΑΙ ΑΣΦΑΛΕΙΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΟΛΑΟΥΖΑ ΑΝΑΠΟΔΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΟΛΗΤΗΡΙ ΜΠΑΤΑΡΙΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΟΛΗΤΗΡΙΑ ΟΛΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΟΛΛΕΣ ΣΤΙΓΜΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΟΜΠΡΕΣΕΡ ΜΠΑΤΑΡΙΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΟΥΝΟΥΠΙΕΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΚΡΕΜΑΣΤΡΑΚΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΛΑΜΠΕΣ ΓΙΑ ΟΘΟΝΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΛΑΣΤΙΧΑΚΙΑ ΔΙΕΛΕΥΣΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΛΑΣΤΙΧΟ ΓΙΑ ΠΛΗΝΤΗΡΙΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΕΛΑΝΙ ΜΑΥΡΟ ΓΙΑ ΕΚΤΥΠΩΤΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΕΤΡΗΤΗΣ ΓΙΑ ΜΠΑΤΑΡΙΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΗΤΡΙΚΕΣ ΥΠΟΛΟΓΥΣΤΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΙΚΡΟ ΤΖΑΚ ΠΡΟΕΚΤΑΣΗ ΜΕΓΑΛΗ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΙΚΡΟΦΩΝΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΙΚΡΟΦΩΝΑ ΑΣΥΡΜΑΤΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΙΚΡΟΦΩΝΑ ΠΥΚΝΩΤΙΚΑ ΔΥΝΑΜΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΙΚΡΟΦΩΝΑ ΧΑΛΑΣΜΕΝΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΟΤΕΡ ΜΕ ΜΕΙΩΤΗΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΠΑΤΑΡΙΕΣ ΔΙΑΦΟΡΕΣ ΓΕΝΙΚΟΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΜΠΟΥΤΟΝΑΚΙΑ ΜΙΚΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΝΤΙΠ ΣΟΥΙΤΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΟΛΟΚΛΗΡΩΜΕΝΑ ΜΕΤΑΛΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΟΡΓΑΝΑ ΠΑΓΚΟΥ!!');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΗΝΕΙΑ ΜΕ ΛΗΨΕΙΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΗΝΕΙΟ ΓΙΑ ΑΤΜΟΣΙΔΕΡΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΙΕΣΟΜΕΤΡΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΙΕΣΟΣΤΑΤΗΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΙΝΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΛΑΚΕΤΑ ΤΣΟΚ ΠΥΚΝΩΤΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΛΑΝΗ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΛΑΣΤΙΚΑ ΓΙΑ Τ ΚΕΡΑΙΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΛΑΣΤΙΚΕΣ ΒΙΔΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΛΗΚΤΡΟΛΟΓΙΟ ΓΙΑ ΤΑΜΠΛΕΤ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΟΛΥΚΛΕΙΔΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΟΛΥΜΕΤΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΟΝΤΙΚΙΑ ΜΕ ΚΑΛΩΔΙΟ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΠΡΕΣΑ ΓΙΑ ΣΙΜ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΡΑΔΙΟΦΩΝΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΑΚΟΥΛΑΚΙΑ ΣΥΣΚΕΥΑΣΙΑΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΕΤ ΑΛΑΓΗΣ ΠΟΡΤΑΣ ΨΥΓΕΙΟΥ');
INSERT INTO [Proion] ([Name]) VALUES (
'σιλικονης λαστιχακια');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΙΦΩΝΙ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΚΛΗΡΟΙ ΔΙΣΚΟΙ ΓΙΑ LAPTOP');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΚΛΗΡΟΙ ΔΙΣΚΟΙ ΕΞΩΤΕΡΙΚΟΙ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΚΛΗΡΟΙ ΔΙΣΚΟΙ ΕΣΩΤΕΡΙΚΟΙ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΥΝΑΓΕΡΜΟΣ LIDL');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΥΡΜΑΤΟΒΟΥΡΤΣΕΣ ΛΕΠΤΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΥΣΚΕΥΕΣ WIFI');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΦΗΚΤΗΡΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΦΥΚΤΗΡΕΣ ΚΟΛΑΡΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΣΧΟΙΝΙ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΗΛΕΦΩΝΙΚΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΗΛΕΧΕΙΡΙΣΤΗΡΙΑ ΚΟΝΤΡΟΛ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΑΝΣΙΣΤΟΡ ΜΕΤΑΛΙΚΑ ΜΕΓΑΛΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΑΝΣΙΣΤΟΡ ΜΕΤΑΛΙΚΑ ΜΙΚΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΑΝΣΙΣΤΟΡ ΜΕΤΑΛΙΚΑ ΠΑΛΕΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΟΦΟΔΟΤΙΚΑ 13.8 VOLT (ΠΟΛΛΑ ΑΜΠΕΡ)');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΟΦΟΔΟΤΙΚΑ ΜΕΓΑΛΑ ΑΠΛΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΟΦΟΔΟΤΙΚΑ ΥΠΟΛΟΓΙΣΤΩΝ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΟΦΟΔΟΤΙΚΟ 30 Β 20 Α');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΡΟΧΑΛΙΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΣΑΝΤΕΣ ΜΕΓΑΛΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΤΣΙΠ ΓΙΑ PS1');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΑΚΟΙ LED');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΑΚΟΣ ΜΕΓΕΘ. ΜΕΓΑΛΟΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΑΣΜΑΤΟΤΕΣΤΕΡ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΙΣΕΣ ΓΙΑ  ΠΛΑΚΕΤΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΓΕΝΙΚΩΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΘΥΛΗΚΑ ΓΕΝΙΚΩΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΦΩΤΟ SONY +++');
INSERT INTO [Proion] ([Name]) VALUES (
'ΧΑΝΤΡΕΣ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΧΑΡΤΙΑ ΔΙΑΦΟΡΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΧΕΡΟΥΛΙΑ ΓΙΑ ΚΟΥΤΙΑ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΨΥΚΤΡΕΣ ΓΙΑ ΜΕΤΑΛΙΚΑ ΤΡΑΝΣΙΣΤΟΡ');
INSERT INTO [Proion] ([Name]) VALUES (
'ΨΥΚΤΡΕΣ ΚΑΙ FAN CPU ΔΙΑΦΟΡΑ FAN');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
2,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
3,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
4,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
5,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
6,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
7,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
8,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
9,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
10,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
11,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
12,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
13,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
14,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
15,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
16,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
21,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
22,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
23,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
24,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
25,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
26,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
27,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
28,'ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
29,'ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
30,'ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
31,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
33,'ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
34,'ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
35,'ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
41,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
42,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
43,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
44,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
45,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
50,'ΕΡΓΑΣΤΗΡΙΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
51,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
52,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
53,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
54,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
55,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
56,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
57,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
58,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
59,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
60,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
61,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
62,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
63,'ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
71,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
72,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
73,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
74,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
75,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
76,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
77,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
78,'ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
97,'ΚΑΤΩ ΑΠΟ ΤΟ ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
98,'ΠΑΝΩ ΑΠΟ ΤΟ ΠΕΤΡΕΛΑΙΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
99,'ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
100,'ΡΑΦΙΕΡΑ ΜΕΓΑΛΗ ΠΑΡΑΘΥΡΟ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
200,'ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
300,'ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
301,'ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
302,'ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
400,'ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
500,'ΑΣΠΡΟ ΡΑΦΑΚΙ ΣΙΔΕΡΕΝΙΟ ΠΙΣΩ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1011,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1012,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1013,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1014,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1015,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1016,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1017,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1018,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1021,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1022,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1023,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1024,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1025,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1026,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1027,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1028,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1031,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1032,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1033,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1034,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1035,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1036,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1037,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1038,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1041,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1042,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1043,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1044,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1045,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1046,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1047,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1048,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1051,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1052,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1053,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1054,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1055,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1056,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1057,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1058,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1061,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1062,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1063,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1064,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1065,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1066,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1067,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1068,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1071,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1072,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1073,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1074,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1075,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1076,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1077,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1078,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1081,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1082,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1083,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1084,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1085,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1086,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1087,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1088,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1091,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1092,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1093,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1094,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1095,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1096,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1097,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1098,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1101,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1102,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1103,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1104,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1105,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1106,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1107,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1108,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1111,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1112,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1113,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1114,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1115,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1116,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1117,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1118,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1121,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1122,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1123,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1124,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1125,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1126,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1127,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1128,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1131,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1132,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1133,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1134,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1135,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1136,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1137,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1138,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1141,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1142,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1143,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1144,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1145,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1146,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1147,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1148,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1151,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1152,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1153,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1154,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1155,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1156,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1157,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1158,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1161,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1162,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1163,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1164,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1165,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1166,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1167,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1168,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1171,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1172,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1173,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1174,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1175,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1176,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1177,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1178,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1181,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1182,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1183,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1184,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1185,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1186,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1187,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1188,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1191,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1192,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1193,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1194,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1195,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1196,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1197,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1198,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1201,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1202,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1203,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1204,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1205,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1206,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1207,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1208,'ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
1500,'ΚΟΚΚΙΝΟ ΣΥΡΤΑΡΑΚΙ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Kouti] ([Id],[Location]) VALUES (
2000,'ΝΤΟΥΛΑΠΑ ΑΥΛΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1,'ΚΑΛΩΔΙΑ LAN','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
2,'POWER PACK ΜΙΚΡΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
3,'POWER PACK ΔΙΑΦΟΡΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
4,'ΑΣΥΡΜΑΤΑ ΠΟΝΤΙΚΙΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
5,'24 V ΣΕ 12 V ΜΕΤΑΤΡΟΠΕΑΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
5,'LED ΤΑΙΝΙΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
5,'LED ΤΑΙΝΙΑ 3 ΧΡΩΜΑΤΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
5,'UPS ΜΙΚΡΟ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
5,'ΕΞΩΤΕΡΙΚΑ ΗΧΕΙΑ CB VHF','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
5,'ΘΗΚΗ ΜΙΚΡΟΦΩΝΟΥ AKG','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
6,'ΚΕΡΑΙΕΣ ΑΣΥΡΜΑΤΩΝ ΔΙΑΦΟΡΕΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
7,'ΚΑΡΤΕΣ ΟΘΟΝΗΣ DVI','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
8,'ΚΑΡΤΕΣ ΟΘΟΝΗΣ VGA','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
9,'ΣΥΣΚΕΥΕΣ WIFI','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
10,'ΚΑΤΑΣΚΕΥΕΣ PCB','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
10,'ΠΡΕΣΑ ΓΙΑ ΣΙΜ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
11,'CD+DVD ΓΙΑ LAPTOP','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
11,'ΑΝΑΜΕΤΑΔΟΤΗΣ WI FI','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
11,'ΠΛΗΚΤΡΟΛΟΓΙΟ ΓΙΑ ΤΑΜΠΛΕΤ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
12,'TV ΓΙΑ ΚΙΝΗΤΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
12,'ΚΑΡΤΕΣ ΗΧΟΥ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
12,'ΚΟΛΗΤΗΡΙ ΜΠΑΤΑΡΙΑΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
12,'ΜΕΤΡΗΤΗΣ ΓΙΑ ΜΠΑΤΑΡΙΕΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
12,'ΠΙΕΣΟΜΕΤΡΟ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
12,'ΤΗΛΕΧΕΙΡΙΣΤΗΡΙΑ ΚΟΝΤΡΟΛ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
13,'ΟΡΓΑΝΑ ΠΑΓΚΟΥ!!','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΑΜΟΡΤΙΣΕΡ ΚΑΡΕΚΛΑΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΔΕΚΤΕΣ GARRISON','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ηλεκτροβαλβιδα ατμοσιδερου','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΗΛΙΑΚΟΣ ΣΥΛΕΚΤΗΣ 12V','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΘΕΡΜΟΜΕΤΡΟ ΗΛΕΚΤΡΟΝΙΚΟ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΘΕΡΜΟΣΤΑΤΗΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'σιλικονης λαστιχακια','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΣΥΝΑΓΕΡΜΟΣ LIDL','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΦΑΚΟΣ ΜΕΓΕΘ. ΜΕΓΑΛΟΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
14,'ΦΩΤΟ SONY +++','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
15,'ΒΑΣΗ  ΣΤΗΡΗΞΗΣ  ΚΑΘΕΤΗ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
15,'ΕΛΙΚΑΣ ΑΕΡΟΠΛΑΝΟΥ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
15,'ΚΑΜΕΡΕΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
15,'ΠΛΑΣΤΙΚΕΣ ΒΙΔΕΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
16,'ΑΙΣΘΗΤΗΡΕΣ ΚΙΝΗΣΗΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
16,'ΜΙΚΡΟΦΩΝΑ ΧΑΛΑΣΜΕΝΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
21,'ΨΥΚΤΡΕΣ ΚΑΙ FAN CPU ΔΙΑΦΟΡΑ FAN','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
22,'POWER PACK LAPTOP','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
23,'POWER RACK ΜΕΓΑΛΑ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
24,'ΚΑΛΩΔΙΑ ΓΙΑ MONITOR','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
25,'ΚΑΛΩΔΙΑ EUROPE','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
26,'ΜΠΑΤΑΡΙΕΣ ΔΙΑΦΟΡΕΣ ΓΕΝΙΚΟΣ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
27,'ΣΚΛΗΡΟΙ ΔΙΣΚΟΙ ΕΣΩΤΕΡΙΚΟΙ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
28,'ΣΑΚΟΥΛΑΚΙΑ ΣΥΣΚΕΥΑΣΙΑΣ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
28,'ΧΑΡΤΙΑ ΔΙΑΦΟΡΑ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
29,'ΘΕΡΜΟΚΟΛΛΑ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
29,'ΘΕΡΜΟΠΙΣΤΟΛΟ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
29,'ΚΟΛΛΕΣ ΣΤΙΓΜΗΣ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
29,'ΣΥΡΜΑΤΟΒΟΥΡΤΣΕΣ ΛΕΠΤΕΣ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
29,'ΤΡΟΦΟΔΟΤΙΚΑ 13.8 VOLT (ΠΟΛΛΑ ΑΜΠΕΡ)','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
30,'SOAR 4040 ΑΝΤΑΠΤOΡΑΣ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
30,'ΠΟΛΥΜΕΤΡΑ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
31,'ΜΙΚΡΟΦΩΝΑ ΑΣΥΡΜΑΤΩΝ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
33,'ΣΚΛΗΡΟΙ ΔΙΣΚΟΙ ΕΞΩΤΕΡΙΚΟΙ','ΡΑΦΙΕΡΑ ΚΟΝΤΗ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
34,'ΠΟΝΤΙΚΙΑ ΜΕ ΚΑΛΩΔΙΟ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
35,'ΜΗΤΡΙΚΕΣ ΥΠΟΛΟΓΥΣΤΩΝ','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
41,'PLL','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
41,'ΚΑΛΩΔΙΑ ΓΙΑ ΤΣΟΚ 50 ΩΜ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
41,'ΡΑΔΙΟΦΩΝΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
42,'ΒΑΣΗ ΟΘΟΝΗΣ PHILIPS','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
42,'ΤΡΟΦΟΔΟΤΙΚΑ ΥΠΟΛΟΓΙΣΤΩΝ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
43,'ΤΡΟΦΟΔΟΤΙΚΑ ΥΠΟΛΟΓΙΣΤΩΝ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
44,'ΤΡΟΦΟΔΟΤΙΚΑ ΥΠΟΛΟΓΙΣΤΩΝ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
45,'ΚΟΛΗΤΗΡΙΑ ΟΛΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
50,'ΑΚΟΥΣΤΙΚΑ','ΕΡΓΑΣΤΗΡΙΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
50,'ΗΧΕΙΑ ΥΠΟΛΟΓΙΣΤΗ','ΕΡΓΑΣΤΗΡΙΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
51,'ΚΑΛΩΔΙΑ ΗΧΟΥ ΧΟΝΔΡΑ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
52,'PEDAL ΗΧΟΥ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
52,'ΚΑΛΩΔΙΑ ΗΧΟΥ ΛΕΠΤΑ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
53,'ΑΝΤΑΠΤΟΡΕΣ VIDEO','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
53,'ΚΑΛΩΔΙΑ VIDEO','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
54,'ΚΑΛΩΔΙΑ USB','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
54,'ΚΑΡΤΕΣ USB','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
55,'ΚΑΛΩΔΙΑ RF','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
56,'POWER PACK ΜΙΚΡΑ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
57,'220 ΒΟΛΤ ΓΕΝΙΚΑ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
57,'ΑΣΦΑΛΕΙΟΔΙΑΚΟΠΤΕΣ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
57,'ΚΑΛΩΔΙΑ ΤΡΟΦΟΔΟΣΙΑΣ ΥΨΗΛΗΣ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
58,'ΚΑΛΩΔΙΑ ΤΡΟΦΟΔΟΣΙΑΣ ΧΑΜΗΛΗΣ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
59,'ΚΑΛΩΔΙΑ ΚΕΡΑΙΑΣ ΤΗΛΕΟΡΑΣΗΣ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
60,'ΚΑΛΩΔΙΑ ΥΠΟΛΟΓΙΣΤΩΝ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
61,'TUBE','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
62,'ΜΙΚΡΟΦΩΝΑ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
63,'ΑΝΤΑΛΛΑΚΤΙΚΑ ΜΙΚΡΟΦΩΝΑ','ΚΑΤΩ ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
71,'ΑΝΤΙΠΑΡΑΣΙΤΙΚΑ ΦΙΛΤΡΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
71,'ΗΛΕΚΤΡΟΝΙΚΟ RELE','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
71,'ΠΗΝΕΙΟ ΓΙΑ ΑΤΜΟΣΙΔΕΡΟ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
72,'ΜΙΚΡΟ ΤΖΑΚ ΠΡΟΕΚΤΑΣΗ ΜΕΓΑΛΗ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
72,'ΣΦΥΚΤΗΡΕΣ ΚΟΛΑΡΩΝ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
72,'ΤΗΛΕΦΩΝΙΚΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
73,'ΑΤΣΑΛΙΝΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
73,'ΓΑΛΒΑΝΙΖΕ ΚΑΙ ΣΥΡΜΑΤΑ ΓΙΑ ΠΗΝΕΙΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
73,'ΣΧΟΙΝΙ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
74,'ΛΑΣΤΙΧΟ ΓΙΑ ΠΛΗΝΤΗΡΙΟ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
75,'ΚΟΥΝΟΥΠΙΕΡΑ','ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
97,'M/T 50.5V/500mA','ΚΑΤΩ ΑΠΟ ΤΟ ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
97,'M/T 600-800-1000V','ΚΑΤΩ ΑΠΟ ΤΟ ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
97,'M/T ΔΙΑΜΟΡΦΩΤΗΣ 100W','ΚΑΤΩ ΑΠΟ ΤΟ ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
97,'M/T ΔΙΑΜΟΡΦΩΤΗΣ 5W','ΚΑΤΩ ΑΠΟ ΤΟ ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
97,'M/T ΔΙΑΜΩΡΦΩΤΗΣ 20W','ΚΑΤΩ ΑΠΟ ΤΟ ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
98,'ΛΑΜΠΕΣ ΓΙΑ ΟΘΟΝΕΣ','ΠΑΝΩ ΑΠΟ ΤΟ ΠΕΤΡΕΛΑΙΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
98,'ΤΣΑΝΤΕΣ ΜΕΓΑΛΕΣ','ΠΑΝΩ ΑΠΟ ΤΟ ΠΕΤΡΕΛΑΙΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 12V-100VA','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 13.5 X 2','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 18V-2A','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 24V-100VA','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 250-250V/500VA','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 2X12V1.2A','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 2X250V/500mA','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T 330-7V','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
99,'M/T ΠΟΛΛΕΣ ΤΑΣΕΙΣ 2 ΤΕΜ','ΚΑΤΩ ΑΠΟ ΜΕΓΑΛΗ ΡΑΦΙΕΡΑ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
100,'ΠΛΑΚΕΤΑ ΤΣΟΚ ΠΥΚΝΩΤΕΣ','ΡΑΦΙΕΡΑ ΜΕΓΑΛΗ ΠΑΡΑΘΥΡΟ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
200,'ΑΝΤΑΠΤΟΡΕΣ VGA - DVI','ΑΣΠΡΟ ΡΑΦΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
300,'ΤΡΟΦΟΔΟΤΙΚΟ 30 Β 20 Α','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
300,'ΦΑΣΜΑΤΟΤΕΣΤΕΡ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
301,'SKANTI TRP5000.. DIAFΟRA','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
301,'ΚΑΛΩΔΙΟ ΓΙΑ ΚΕΡΑΙΑ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
301,'ΚΛΕΙΔΑΡΙΕΣ ΑΣΦΑΛΕΙΑΣ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
301,'ΠΙΕΣΟΣΤΑΤΗΣ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
301,'ΣΙΦΩΝΙ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
302,'RELE ΙΣΧΥΟΣ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
302,'ΑΕΡΟΦΥΛΛΟΙ ΠΥΚΝΩΤΕΣ ΑΡΕΟΦΥΛΛΟΙ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
302,'ΠΗΝΕΙΑ ΜΕ ΛΗΨΕΙΣ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
302,'ΠΛΑΣΤΙΚΑ ΓΙΑ Τ ΚΕΡΑΙΩΝ','ΠΑΝΑΓΙΩΤΗΣ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'LED 1W ΑΝΤΑΛΑΚΤΙΚΑ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΓΩΝΙΕΣ ΓΙΑ ΡΑΦΙΑ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΚΟΛΑΟΥΖΑ ΑΝΑΠΟΔΑ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΜΕΛΑΝΙ ΜΑΥΡΟ ΓΙΑ ΕΚΤΥΠΩΤΕΣ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΜΟΤΕΡ ΜΕ ΜΕΙΩΤΗΡΑ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΠΛΑΝΗ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΠΟΛΥΚΛΕΙΔΟ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΣΕΤ ΑΛΑΓΗΣ ΠΟΡΤΑΣ ΨΥΓΕΙΟΥ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΦΑΚΟΙ LED','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
400,'ΧΕΡΟΥΛΙΑ ΓΙΑ ΚΟΥΤΙΑ','ΑΣΠΡΟ ΡΑΦΙ - ΜΠΛΕ ΚΟΥΤΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
500,'ΕΚΧΥΛΩΤΕΣ','ΑΣΠΡΟ ΡΑΦΑΚΙ ΣΙΔΕΡΕΝΙΟ ΠΙΣΩ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1011,'XR2206CP','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1011,'ΤΣΙΠ ΓΙΑ PS1','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1012,'ΒΑΣΗ ΓΙΑ ΚΑΛΩΔΙΟΤΑΙΝΙΑ 16 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1013,'ΚΕΡΑΜΙΚΟΙ ΚΡΥΣΤΑΛΟΙ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1014,'4 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1015,'6 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1016,'ΒΑΣΕΙΣ 6 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1017,'8 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1018,'ΒΑΣΕΙΣ 8 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1021,'7805','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1021,'7805 ΜΙΚΡΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1022,'7812','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1022,'7812 ΜΙΚΡΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1023,'IRF 640','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1024,'7809','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1024,'ΔΥΑΔΙΚΟΙ ΔΙΑΚΟΠΤΕΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1025,'7815','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1026,'7912','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1027,'7875','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1028,'7915','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1038,'ΚΑΛΩΔΙΟΤΑΙΝΙΑ 2Χ16 ΠΟΔΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1041,'7808','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1042,'7905','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1043,'7906','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1044,'ΓΕΦΥΡΕΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1045,'ΠΙΝΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1046,'7909','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1047,'7824','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1048,'7924','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1048,'ΔΙΑΜΩΡΦΩΤΗΣ ΜΙΚΡΟΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1071,'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΓΕΝΙΚΩΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1072,'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΘΥΛΗΚΑ ΓΕΝΙΚΩΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1073,'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΓΕΝΙΚΩΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1074,'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΘΥΛΗΚΑ ΓΕΝΙΚΩΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1075,'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΓΕΝΙΚΩΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1076,'AUDIO ΣΑΣΙΟΥ ΠΛΑΚΕΤΑΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1077,'ΦΥΣΕΣ ΤΡΟΦΟΔΟΣΙΑΣ ΓΕΝΙΚΩΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1078,'ΜΠΟΥΤΟΝΑΚΙΑ ΜΙΚΡΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1083,'ΔΕΚΤΕΣ ΥΠΕΡΥΘΡΩΝ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1085,'ΑΝΤΑΛΑΚΤΙΚΑ ΓΙΑ ΠΟΝΤΙΚΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1091,'1N34A','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1091,'OA91','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1091,'ΔΙΟΔΟΙ ΓΕΡΜΑΝΙΟΥ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1092,'ΨΥΚΤΡΕΣ ΓΙΑ ΜΕΤΑΛΙΚΑ ΤΡΑΝΣΙΣΤΟΡ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1093,'BUT11A','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1094,'ΟΛΟΚΛΗΡΩΜΕΝΑ ΜΕΤΑΛΙΚΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1096,'ΤΡΑΝΣΙΣΤΟΡ ΜΕΤΑΛΙΚΑ ΜΕΓΑΛΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1097,'ΤΡΑΝΣΙΣΤΟΡ ΜΕΤΑΛΙΚΑ ΠΑΛΕΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1098,'ΤΡΑΝΣΙΣΤΟΡ ΜΕΤΑΛΙΚΑ ΜΙΚΡΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1102,'BAZER','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1103,'ΑΝΤΙΚΕΡΑΥΝΙΚΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1106,'ΦΙΣΕΣ ΓΙΑ  ΠΛΑΚΕΤΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1107,'ΚΑΨΕΣ ΜΙΚΡΟΦΩΝΟΥ ΠΥΚΝΩΤΗΚΕΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1107,'ΧΑΝΤΡΕΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1108,'ΚΑΨΕΣ ΜΙΚΡΟΦΩΝΟΥ ΔΥΝΑΜΙΚΕΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1108,'ΦΙΣΕΣ ΓΙΑ  ΠΛΑΚΕΤΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1111,'ΝΤΙΠ ΣΟΥΙΤΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1112,'ΛΑΣΤΙΧΑΚΙΑ ΔΙΕΛΕΥΣΗΣ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1124,'ΚΡΕΜΑΣΤΡΑΚΙΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1142,'ΕΝΚΟΡΝΤΕΡ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1151,'LED ΥΠΕΡΥΘΡΑ','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1161,'50ΝΟ6','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1161,'60Ν06','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1162,'AN 7205','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1162,'D 2030A','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1162,'TA 7342P','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1163,'IRF 620','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1163,'IRF 630','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1163,'IRF 640','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1163,'IRF 740','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1163,'IRF 840','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1164,'IRF 1010','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1166,'CEP 83A3','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1167,'BYV 42E','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1168,'CEP 3205','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1168,'IRF 3205','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1168,'IRF Z46N','ΠΑΝΤΖΟΥΡΙ');
INSERT INTO [Sxesi] ([KoutiId],[ProionName],[KoutiLocation]) VALUES (
1500,'TRANSISTOR RF','ΚΟΚΚΙΝΟ ΣΥΡΤΑΡΑΚΙ ΠΑΝΤΖΟΥΡΙ');
COMMIT;

