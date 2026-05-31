using System;
using System.Collections.Generic;
using System.Data.SqlClient;

class Program
{
    static string conStr = "Server=ICS-LT-FDHKR24;Database=TrainProj;Trusted_Connection=True;";
    static SqlConnection con = new SqlConnection(conStr);

    static void Title(string text)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"         {text.ToUpper()}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.ResetColor();
    }

    static void Success(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n" + msg);
        Console.ResetColor();
    }

    static void ErrorMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n" + msg);
        Console.ResetColor();
    }

    static int ReadInt()
    {
        int val;
        while (!int.TryParse(Console.ReadLine(), out val))
            ErrorMsg("Enter valid number!");
        return val;
    }

    static void Main()
    {
        while (true)
        {
            Title("Train Reservation System");

            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Login");
            Console.WriteLine("3. Exit");

            int choice = ReadInt();
            if (choice == 3) return;

            int userId = 0;
            string role = "";

            if (choice == 1)
            {
                Console.Write("Username: ");
                string u = Console.ReadLine();
                Console.Write("Password: ");
                string p = Console.ReadLine();

                SqlCommand cmd = new SqlCommand(
                    "SELECT UserId FROM Users WHERE Username=@u AND UserPassword=@p AND Role='Admin'", con);

                cmd.Parameters.AddWithValue("@u", u);
                cmd.Parameters.AddWithValue("@p", p);

                con.Open();
                var dr = cmd.ExecuteReader();

                if (dr.Read()) role = "Admin";
                else { ErrorMsg("Invalid Admin"); con.Close(); continue; }

                con.Close();
            }
            else
            {
                Console.Write("Username: ");
                string uname = Console.ReadLine();

                Console.Write("Password: ");
                string pwd = Console.ReadLine();

                SqlCommand login = new SqlCommand(
                    "SELECT UserId FROM Users WHERE Username=@u AND UserPassword=@p", con);

                login.Parameters.AddWithValue("@u", uname);
                login.Parameters.AddWithValue("@p", pwd);

                con.Open();
                var dr = login.ExecuteReader();

                if (dr.Read())
                {
                    userId = (int)dr["UserId"];
                    role = "User";
                }
                else { ErrorMsg("Invalid login"); con.Close(); continue; }

                con.Close();
            }

            while (true)
            {
                Title(role == "Admin" ? "Admin Menu" : "User Menu");

                if (role == "Admin")
                {
                    Console.WriteLine("1. Add Train");
                    Console.WriteLine("2. View Trains");
                    Console.WriteLine("3. View Passengers");
                    Console.WriteLine("4. Delete Train");
                    Console.WriteLine("5. Logout");

                    int c = ReadInt();

                    if (c == 1) AddTrain();
                    else if (c == 2) ViewTrains();
                    else if (c == 3) ViewPassengerDetails();
                    else if (c == 4) DeleteTrain();
                    else break;
                }
                else
                {
                    Console.WriteLine("1. Book Ticket");
                    Console.WriteLine("2. View My Bookings");
                    Console.WriteLine("3. Cancel Ticket");
                    Console.WriteLine("4. Logout");

                    int c = ReadInt();

                    if (c == 1) BookTicket(userId);
                    else if (c == 2) ViewMyBookings(userId);
                    else if (c == 3) CancelTicket();
                    else break;
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }
        }
    }

    static void AddTrain()
    {
        Title("Add Train");

        Console.Write("Train No: ");
        int no = ReadInt();

        Console.Write("Train Name: ");
        string name = Console.ReadLine();

        Console.Write("From: ");
        string from = Console.ReadLine();

        Console.Write("To: ");
        string to = Console.ReadLine();

        Console.Write("Departure (HH:mm): ");
        TimeSpan dep = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Arrival (HH:mm): ");
        TimeSpan arr = TimeSpan.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(@"
        INSERT INTO Train VALUES(@no,@n,@f,@t,50,100,40,500,20,800,0,@d,@a)", con);

        cmd.Parameters.AddWithValue("@no", no);
        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@f", from);
        cmd.Parameters.AddWithValue("@t", to);
        cmd.Parameters.AddWithValue("@d", dep);
        cmd.Parameters.AddWithValue("@a", arr);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        Success("Train Added Successfully!");
    }

    static void ViewTrains()
    {
        Title("Available Trains");

        con.Open();

        var dr = new SqlCommand("SELECT * FROM Train WHERE IsDeleted=0", con).ExecuteReader();

        List<dynamic> trains = new List<dynamic>();

        while (dr.Read())
        {
            trains.Add(new
            {
                TrainNo = (int)dr["TrainNo"],
                Name = dr["TrainName"],
                From = dr["FromStation"],
                To = dr["ToStation"],
                Dep = (TimeSpan)dr["DepartureTime"],
                Arr = (TimeSpan)dr["ArrivalTime"]
            });
        }

        dr.Close();

        foreach (var t in trains)
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.WriteLine($"{t.Name} ({t.TrainNo})");
            Console.WriteLine($"{t.From} -> {t.To}");
            Console.WriteLine($"{t.Dep:hh\\:mm} -> {t.Arr:hh\\:mm}");

            SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) FROM Passenger p
            JOIN Booking b ON p.BookingId=b.BookingId
            WHERE b.TrainNo=@t AND IsCancelled=0", con);

            cmd.Parameters.AddWithValue("@t", t.TrainNo);

            int booked = (int)cmd.ExecuteScalar();
            int total = 50;

            Console.WriteLine($"Seats Available: {total - booked}/{total}");

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
        }

        con.Close();
    }

    static void BookTicket(int userId)
    {
        Title("Book Ticket");

        Console.Write("From: ");
        string from = Console.ReadLine();

        Console.Write("To: ");
        string to = Console.ReadLine();

        con.Open();

        var dr = new SqlCommand(
            "SELECT * FROM Train WHERE FromStation=@f AND ToStation=@t AND IsDeleted=0", con)
        {
            Parameters = {
            new SqlParameter("@f", from),
            new SqlParameter("@t", to)
        }
        }.ExecuteReader();

        List<int> trains = new List<int>();
        int i = 1;

        Console.WriteLine("\nAvailable Trains:");

        while (dr.Read())
        {
            trains.Add((int)dr["TrainNo"]);
            Console.WriteLine($"{i}. {dr["TrainName"]}");
            i++;
        }

        dr.Close();

        if (trains.Count == 0)
        {
            ErrorMsg("No trains available!");
            con.Close();
            return;
        }

        Console.Write("\nSelect Train: ");
        int choice = ReadInt();

        if (choice < 1 || choice > trains.Count)
        {
            ErrorMsg("Invalid train selection!");
            con.Close();
            return;
        }

        int trainNo = trains[choice - 1];

        SqlCommand seatCmd = new SqlCommand(@"
        SELECT SeatNumber FROM Passenger p
        JOIN Booking b ON p.BookingId = b.BookingId
        WHERE b.TrainNo=@t AND p.IsCancelled=0", con);

        seatCmd.Parameters.AddWithValue("@t", trainNo);

        var seatDr = seatCmd.ExecuteReader();

        List<int> booked = new List<int>();

        while (seatDr.Read())
            booked.Add((int)seatDr["SeatNumber"]);

        seatDr.Close();

        List<int> available = new List<int>();

        for (int s = 1; s <= 50; s++)
            if (!booked.Contains(s))
                available.Add(s);

        if (available.Count == 0)
        {
            ErrorMsg("Train is FULL!");
            con.Close();
            return;
        }

        Console.WriteLine("\nAvailable Seats:");
        available.ForEach(s => Console.Write(s + " "));
        Console.WriteLine();

        Console.Write("\nNumber of Passengers (Max 3): ");
        int count = ReadInt();

        if (count < 1 || count > 3)
        {
            ErrorMsg("You can book maximum 3 tickets only!");
            con.Close();
            return;
        }

        if (count > available.Count)
        {
            ErrorMsg("Not enough seats available!");
            con.Close();
            return;
        }

        int pnr = new Random().Next(100000, 999999);

        new SqlCommand(@"
    INSERT INTO Booking VALUES(@id,GETDATE(),GETDATE(),@t,'Sleeper',@c,1000,@uid,0)", con)
        {
            Parameters = {
            new SqlParameter("@id", pnr),
            new SqlParameter("@t", trainNo),
            new SqlParameter("@c", count),
            new SqlParameter("@uid", userId)
        }
        }.ExecuteNonQuery();

        Console.WriteLine("\nEnter Passenger Details:\n");

        List<int> chosenSeats = new List<int>();

        for (int k = 0; k < count; k++)
        {
            Console.WriteLine($"Passenger {k + 1}");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = ReadInt();

            string gender;
            while (true)
            {
                Console.Write("Gender (M/F): ");
                gender = Console.ReadLine().ToUpper();

                if (gender == "M" || gender == "F") break;
                ErrorMsg("Invalid gender!");
            }

            Console.WriteLine("Select ID Type:");
            Console.WriteLine("1. Aadhaar");
            Console.WriteLine("2. PAN");
            Console.WriteLine("3. Passport");

            int idChoice = ReadInt();

            string idType;

            if (idChoice == 1) idType = "Aadhaar";
            else if (idChoice == 2) idType = "PAN";
            else if (idChoice == 3) idType = "Passport";
            else idType = "Aadhaar";

            Console.Write("ID Number: ");
            string idNumber = Console.ReadLine();

            // ✅ Seat selection
            int seat;

            while (true)
            {
                Console.Write("Choose Seat Number: ");
                seat = ReadInt();

                if (available.Contains(seat) && !chosenSeats.Contains(seat))
                {
                    chosenSeats.Add(seat);
                    break;
                }

                ErrorMsg("Invalid or already chosen seat!");
            }

            new SqlCommand(@"
        INSERT INTO Passenger
        (BookingId, Name, Age, Gender, SeatNumber, IDType, IDNumber)
        VALUES(@b,@n,@a,@g,@s,@idt,@idn)", con)
            {
                Parameters = {
                new SqlParameter("@b", pnr),
                new SqlParameter("@n", name),
                new SqlParameter("@a", age),
                new SqlParameter("@g", gender),
                new SqlParameter("@s", seat),
                new SqlParameter("@idt", idType),
                new SqlParameter("@idn", idNumber)
            }
            }.ExecuteNonQuery();

            Console.WriteLine($"✅ Seat {seat} booked\n");
        }

        con.Close();

        Success($"Booking Successful!\nPNR: {pnr}\nPassengers: {count}");
    }

    static void CancelTicket()
    {
        Title("Cancel Ticket");

        Console.Write("Booking ID: ");
        int bid = ReadInt();

        con.Open();

        var dr = new SqlCommand("SELECT SeatNumber,Name FROM Passenger WHERE BookingId=@b AND IsCancelled=0", con)
        {
            Parameters = { new SqlParameter("@b", bid) }
        }.ExecuteReader();

        List<int> seats = new List<int>();

        while (dr.Read())
        {
            int s = (int)dr["SeatNumber"];
            seats.Add(s);
            Console.WriteLine($"Seat {s} - {dr["Name"]}");
        }

        dr.Close();

        if (seats.Count == 0)
        {
            ErrorMsg("No active tickets!");
            con.Close();
            return;
        }

        int seatChoice = ReadInt();

        Console.Write("Confirm? (Y/N): ");
        if (Console.ReadLine().ToUpper() != "Y")
        {
            con.Close();
            return;
        }

        new SqlCommand("UPDATE Passenger SET IsCancelled=1 WHERE BookingId=@b AND SeatNumber=@s", con)
        {
            Parameters = { new SqlParameter("@b", bid), new SqlParameter("@s", seatChoice) }
        }.ExecuteNonQuery();

        con.Close();
        Success("Ticket Cancelled!");
    }

    static void ViewMyBookings(int userId)
    {
        Title("Select Train");

        con.Open();

        var tCmd = new SqlCommand(@"
        SELECT DISTINCT t.TrainNo, t.TrainName
        FROM Booking b
        JOIN Train t ON b.TrainNo = t.TrainNo
        WHERE b.UserId = @u", con);

        tCmd.Parameters.AddWithValue("@u", userId);

        var tDr = tCmd.ExecuteReader();

        List<int> trainIds = new List<int>();
        int i = 1;

        while (tDr.Read())
        {
            trainIds.Add((int)tDr["TrainNo"]);
            Console.WriteLine($"{i}. {tDr["TrainName"]} ({tDr["TrainNo"]})");
            i++;
        }

        tDr.Close();

        if (trainIds.Count == 0)
        {
            ErrorMsg("No bookings found!");
            con.Close();
            return;
        }

        Console.Write("\nSelect Train: ");
        int choice = ReadInt();

        if (choice < 1 || choice > trainIds.Count)
        {
            ErrorMsg("Invalid selection!");
            con.Close();
            return;
        }

        int trainNo = trainIds[choice - 1];

        var bCmd = new SqlCommand(@"
        SELECT BookingId 
        FROM Booking 
        WHERE TrainNo = @t AND UserId = @u", con);

        bCmd.Parameters.AddWithValue("@t", trainNo);
        bCmd.Parameters.AddWithValue("@u", userId);

        var bDr = bCmd.ExecuteReader();

        List<int> bookingIds = new List<int>();

        while (bDr.Read())
        {
            bookingIds.Add((int)bDr["BookingId"]);
        }

        bDr.Close();

        Title("Passenger Details");

        bool found = false;

        foreach (int bid in bookingIds)
        {
            var pCmd = new SqlCommand(@"
            SELECT Name, SeatNumber, IsCancelled 
            FROM Passenger 
            WHERE BookingId=@b", con);

            pCmd.Parameters.AddWithValue("@b", bid);

            var pDr = pCmd.ExecuteReader();

            while (pDr.Read())
            {
                found = true;

                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                Console.WriteLine($"Booking ID : {bid}");
                Console.WriteLine($"Name       : {pDr["Name"]}");

                bool isCancelled = pDr["IsCancelled"] != DBNull.Value &&
                                   Convert.ToBoolean(pDr["IsCancelled"]);

                if (isCancelled)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Status     : CANCELLED");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Seat No    : {pDr["SeatNumber"]}");
                    Console.WriteLine("Status     : ACTIVE");
                }

                Console.ResetColor();
            }

            pDr.Close();
        }

        if (!found)
        {
            ErrorMsg("No passengers found!");
        }

        con.Close();
    }


    static void ViewPassengerDetails()
    {
        Title("Select Train");

        con.Open();

        var dr = new SqlCommand(
            "SELECT TrainNo, TrainName FROM Train WHERE IsDeleted = 0", con)
            .ExecuteReader();

        List<int> trains = new List<int>();
        int i = 1;

        while (dr.Read())
        {
            trains.Add((int)dr["TrainNo"]);
            Console.WriteLine($"{i}. {dr["TrainName"]} ({dr["TrainNo"]})");
            i++;
        }

        dr.Close();

        if (trains.Count == 0)
        {
            ErrorMsg("No trains available!");
            con.Close();
            return;
        }

        Console.Write("\nSelect Train: ");
        int choice = ReadInt();

        if (choice < 1 || choice > trains.Count)
        {
            ErrorMsg("Invalid selection!");
            con.Close();
            return;
        }

        int trainNo = trains[choice - 1];

        var pDr = new SqlCommand(@"
        SELECT b.BookingId, p.Name, p.SeatNumber, p.IsCancelled
        FROM Passenger p
        JOIN Booking b ON p.BookingId = b.BookingId
        WHERE b.TrainNo = @t", con);

        pDr.Parameters.AddWithValue("@t", trainNo);

        var reader = pDr.ExecuteReader();

        Title("Passenger Details");

        bool found = false;

        while (reader.Read())
        {
            found = true;

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.WriteLine($"Booking ID : {reader["BookingId"]}");
            Console.WriteLine($"Name       : {reader["Name"]}");

            bool isCancelled = reader["IsCancelled"] != DBNull.Value &&
                               Convert.ToBoolean(reader["IsCancelled"]);

            if (isCancelled)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status     : CANCELLED");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Seat No    : {reader["SeatNumber"]}");
                Console.WriteLine("Status     : ACTIVE");
            }

            Console.ResetColor();
        }

        if (!found)
        {
            ErrorMsg("No passengers in this train!");
        }

        reader.Close();
        con.Close();
    }
    static void DeleteTrain()
    {
        Console.Write("Train No: ");
        int no = ReadInt();

        con.Open();

        int active = (int)new SqlCommand(@"
        SELECT COUNT(*) FROM Passenger p
        JOIN Booking b ON p.BookingId=b.BookingId
        WHERE b.TrainNo=@n AND IsCancelled=0", con)
        { Parameters = { new SqlParameter("@n", no) } }
        .ExecuteScalar();

        if (active > 0)
            ErrorMsg("Cannot delete train with active bookings!");
        else
        {
            new SqlCommand("UPDATE Train SET IsDeleted=1 WHERE TrainNo=@n", con)
            { Parameters = { new SqlParameter("@n", no) } }.ExecuteNonQuery();

            Success("Train deleted");
        }

        con.Close();
    }
}
