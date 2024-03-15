namespace MiPark
{
    public static class CarData
    {
        public static Dictionary<string, List<string>> BrandsAndModels = new Dictionary<string, List<string>>()
        {
            {"Alfa Romeo", new List<string> {"147", "156", "159", "Giulietta", "MiTo", "Brera", "Spider", "4C", "Giulia", "Stelvio", "GTV", "8C Competizione"}},
            {"Aston Martin", new List<string> {"DB7", "DB9", "DBS", "V8 Vantage", "V12 Vantage", "DB11", "Vanquish", "Rapide", "Valkyrie", "DBX", "Vantage", "Virage", "DBS Superleggera", "One-77"}},
            {"Audi", new List<string> {"A1", "A2", "A3", "A4", "A4 Allroad", "A5", "A6", "A6 Allroad", "A7", "A8","Q2", "Q3", "Q4 e-tron", "Q5", "Q7", "Q8","TT", "R8","e-tron", "e-tron GT", "Q3 Sportback", "Q5 Sportback", "RS3", "RS4", "RS5", "RS6", "RS7", "RS Q3", "RS Q8","S3", "S4", "S5", "S6", "S7", "S8", "SQ5", "SQ7", "SQ8","TT RS", "TTS"}},
            {"BMW", new List<string> {"1 Series", "2 Series", "3 Series", "4 Series", "5 Series", "6 Series", "7 Series", "8 Series", "X1", "X2", "X3", "X4", "X5", "X6", "X7", "Z4", "M2", "M3", "M4", "M5", "M6", "M8", "X5 M", "X6 M", "i3", "i4", "i8", "iX3", "iX", "Z3"}},
            {"Bentley", new List<string> {"Arnage", "Azure", "Brooklands", "Continental GT", "Continental Flying Spur", "Continental GTC", "Bentayga", "Mulsanne", "Flying Spur", "Continental Supersports"}},
            {"Bugatti", new List<string> {"Veyron", "Chiron", "Divo", "Centodieci", "Bolide"}},
            {"Chevrolet", new List<string> {"Aveo", "Cruze", "Captiva", "Spark", "Orlando", "Camaro", "Corvette", "Malibu", "Trax", "Volt"}},
            {"Chrysler", new List<string> {"300C", "PT Cruiser", "Crossfire", "Voyager", "Sebring", "Grand Voyager"}},
            {"Citroën", new List<string> {"C1", "C2", "C3", "C3 Picasso", "C4", "C4 Cactus", "C4 Picasso", "C5", "C6", "C8", "Berlingo", "DS3", "DS4", "DS5", "Xsara Picasso"}},
            {"Cupra", new List<string> {"Leon", "Ateca", "Formentor", "Born"}},
            {"DS Automobiles", new List<string> {"DS 3", "DS 4", "DS 5", "DS 7 Crossback", "DS 9"}},
            {"Dacia", new List<string> {"Logan", "Sandero", "Duster", "Lodgy", "Dokker", "Spring Electric"}},
            {"Dodge", new List<string> {"Caliber", "Challenger", "Charger", "Viper"}},
            {"Ferrari", new List<string> {"360", "F430", "458 Italia", "488 GTB", "F8 Tributo", "LaFerrari", "812 Superfast", "SF90 Stradale"}},
            {"Fiat", new List<string> {"500", "Panda", "Punto", "Grande Punto", "Tipo", "500X", "500L"}},
            {"Ford", new List<string> {"Fiesta", "Focus", "Mondeo", "Kuga", "Mustang", "EcoSport", "Puma", "Explorer", "Galaxy"}},
            {"Honda", new List<string> {"Civic", "Accord", "CR-V", "Jazz", "HR-V", "NSX"}},
            {"Hyundai", new List<string> {"i10", "i20", "i30", "Tucson", "Santa Fe", "Kona", "Ioniq", "Palisade"}},
            {"Infiniti", new List<string> {"Q50", "Q60", "QX50", "QX70", "QX80"}},
            {"Jaguar", new List<string> {"XE", "XF", "XJ", "F-Type", "E-Pace", "F-Pace", "I-Pace"}},
            {"Jeep", new List<string> {"Renegade", "Compass", "Cherokee", "Grand Cherokee", "Wrangler"}},
            {"Kia", new List<string> {"Picanto", "Rio", "Ceed", "Sportage", "Sorento", "Stinger", "Niro", "EV6"}},
            {"Lamborghini", new List<string> {"Gallardo", "Huracan", "Aventador", "Urus"}},
            {"Lancia", new List<string> {"Ypsilon", "Delta", "Musa"}},
            {"Land Rover", new List<string> {"Discovery", "Freelander", "Range Rover", "Range Rover Sport", "Range Rover Evoque", "Discovery Sport", "Range Rover Velar"}},
            {"Lexus", new List<string> {"IS", "ES", "GS", "LS", "RX", "NX", "UX", "LC", "LX"}},
            {"Lotus", new List<string> {"Elise", "Exige", "Evora", "Emira"}},
            {"MG", new List<string> {"ZS", "HS", "MG3", "MG5", "MG6"}},
            {"MINI", new List<string> {"Cooper", "Cooper S", "Countryman", "Clubman", "Electric"}},
            {"Maserati", new List<string> {"Ghibli", "Quattroporte", "GranTurismo", "Levante"}},
            {"Mazda", new List<string> {"2", "3", "6", "CX-3", "CX-5", "CX-30", "MX-5"}},
            {"McLaren", new List<string> {"MP4-12C", "650S", "570S", "720S", "P1", "GT", "765LT"}},
            {"Mercedes-Benz", new List<string> {"A-Class", "B-Class", "C-Class", "E-Class", "S-Class", "GLA", "GLC", "GLE", "GLS", "AMG GT", "CLS", "SLK", "SL", "EQC"}},
            {"Mitsubishi", new List<string> {"Lancer", "Outlander", "Pajero", "ASX", "Eclipse Cross"}},
            {"Nissan", new List<string> {"Micra", "Juke", "Qashqai", "X-Trail", "Leaf", "GT-R"}},
            {"Opel/Vauxhall", new List<string> {"Corsa", "Astra", "Insignia", "Crossland X", "Grandland X", "Mokka"}},
            {"Peugeot", new List<string> {"208", "308", "508", "2008", "3008", "5008", "RCZ"}},
            {"Polestar", new List<string> {"1", "2"}},
            {"Porsche", new List<string> {"911", "Boxster", "Cayman", "Panamera", "Cayenne", "Macan", "Taycan"}},
            {"Renault", new List<string> {"Clio", "Megane", "Scenic", "Laguna", "Espace", "Captur", "Kadjar", "Zoe"}},
            {"Rolls-Royce", new List<string> {"Phantom", "Ghost", "Wraith", "Dawn", "Cullinan"}},
            {"SEAT", new List<string> {"Ibiza", "Leon", "Ateca", "Tarraco", "Arona"}},
            {"Skoda", new List<string> {"Fabia", "Octavia", "Superb", "Kodiaq", "Karoq", "Scala", "Enyaq iV"}},
            {"Smart", new List<string> {"Fortwo", "Forfour", "EQ Fortwo", "EQ Forfour"}},
            {"Subaru", new List<string> {"Impreza", "Forester", "Outback", "BRZ", "XV"}},
            {"Suzuki", new List<string> {"Swift", "Vitara", "SX4 S-Cross", "Ignis", "Jimny"}},
            {"Tesla", new List<string> {"Roadster", "Model S", "Model X", "Model 3", "Model Y"}},
            {"Toyota", new List<string> {"Yaris", "Corolla", "Camry", "RAV4", "Prius", "Land Cruiser", "C-HR", "Supra"}},
            {"Volkswagen", new List<string> {"Golf", "Polo", "Passat", "Tiguan", "Touareg", "Arteon", "T-Roc", "ID.3", "ID.4"}},
            {"Volvo", new List<string> {"S60", "S90", "V60", "V90", "XC40", "XC60", "XC90"}}
        };

        public static List<string> VehicleColors = new List<string>
        {
            "Amarillo",
            "Azul",
            "Beige",
            "Blanco",
            "Dorado",
            "Gris",
            "Marron",
            "Naranja",
            "Negro",
            "Plata",
            "Rojo",
            "Rosa",
            "Verde"
        };
    }
}
