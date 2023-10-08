using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallNumber = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Halls_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    MovieTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MovieTypes_MovieTypeId",
                        column: x => x.MovieTypeId,
                        principalTable: "MovieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Producers = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AgeLimit = table.Column<int>(type: "int", nullable: false),
                    IndependentRate = table.Column<double>(type: "float(4)", precision: 4, scale: 2, nullable: false),
                    UsersRate = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MovieTrailerUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seanses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seanses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seanses_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seanses_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seanses_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    UserDetailsId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.MovieId, x.UserDetailsId });
                    table.ForeignKey(
                        name: "FK_Favourites_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    UserDetailsId = table.Column<int>(type: "int", nullable: false),
                    PromocodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Promocodes_PromocodeId",
                        column: x => x.PromocodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rate = table.Column<double>(type: "float(2)", maxLength: 10, precision: 2, scale: 2, nullable: false),
                    MovieDetailsId = table.Column<int>(type: "int", nullable: false),
                    UserDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_MovieDetails_MovieDetailsId",
                        column: x => x.MovieDetailsId,
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    SeanseId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seanses_SeanseId",
                        column: x => x.SeanseId,
                        principalTable: "Seanses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, "Vul. Bogdana Khmelnitskogo", "Kiyv", "stupka@gmail.com", "Stupka", "380997813842" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Comedy" },
                    { 4, "Drama" },
                    { 5, "Horror" },
                    { 6, "Romance" },
                    { 7, "Science fiction" },
                    { 8, "Fantasy" },
                    { 9, "Historical" },
                    { 10, "Crime" },
                    { 11, "Thriller" },
                    { 12, "Western" },
                    { 13, "Animation" }
                });

            migrationBuilder.InsertData(
                table: "MovieTypes",
                columns: new[] { "Id", "MediaType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Cost" },
                values: new object[,]
                {
                    { 1, 100m },
                    { 2, 200m },
                    { 3, 300m }
                });

            migrationBuilder.InsertData(
                table: "Promocodes",
                columns: new[] { "Id", "Name", "Percentage" },
                values: new object[,]
                {
                    { 1, "none", 0 },
                    { 2, "Stupka50", 50 },
                    { 3, "Stupka20", 20 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "SeatTypes",
                columns: new[] { "Id", "Price", "Type" },
                values: new object[,]
                {
                    { 1, 10m, 0 },
                    { 2, 15m, 1 },
                    { 3, 25m, 2 },
                    { 4, 35m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "CinemaId", "HallNumber" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Duration", "MovieTypeId", "OriginalTitle", "PosterUrl", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 145, 1, "Shrek", "https://i.etsystatic.com/27475238/r/il/f9eed6/3758942437/il_fullxfull.3758942437_9564.jpg", new DateTime(1999, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Зелений чолов'яга" },
                    { 2, 120, 2, "Titanic", "https://i.ebayimg.com/images/g/MHIAAOSwsMhiib8p/s-l1600.jpg", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Затонувший корабель" },
                    { 3, 160, 3, "Borat", "https://m.media-amazon.com/images/M/MV5BMTk0MTQ3NDQ4Ml5BMl5BanBnXkFtZTcwOTQ3OTQzMw@@._V1_.jpg", new DateTime(2006, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Смішний казах" },
                    { 4, 170, 1, "Mask", "https://m.media-amazon.com/images/M/MV5BOWExYjI5MzktNTRhNi00Nzg2LThkZmQtYWVkYjRlYWI2MDQ4XkEyXkFqcGdeQXVyNTAyODkwOQ@@._V1_.jpg", new DateTime(1999, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Зелений чорт" },
                    { 5, 120, 2, "Kung Fu Panda", "https://static.posters.cz/image/1300/poster/kung-fu-panda-i13408.jpg", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чорнобілий ведмідь" },
                    { 6, 135, 3, "Avatar", "https://i.ebayimg.com/images/g/URcAAOSwC31jZQ11/s-l500.jpg", new DateTime(2009, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сині люди" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "Admin", "admin123", "380999999999", 1 },
                    { 2, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "User", "User", "user123", "380111111111", 2 },
                    { 3, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "zxc@gmail.com", "Admin", "Admin", "admin123", "380999999999", 2 },
                    { 4, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "qsd@gmail.com", "User", "User", "user123", "380111111111", 2 },
                    { 5, new DateTime(2000, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "asd@gmail.com", "Admin", "Admin", "admin123", "380999999999", 2 },
                    { 6, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "qwe@gmail.com", "User", "User", "user123", "380111111111", 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieDetails",
                columns: new[] { "Id", "AgeLimit", "Country", "Description", "EndDate", "IndependentRate", "MovieId", "MovieTrailerUrl", "Producers", "StartDate", "UsersRate" },
                values: new object[,]
                {
                    { 1, 5, "USA", "Мирний зелений чолов'яга, намагається релаксувати в своєму болоті, але спочатку йому заважає цирк, а потім новий надокучливий друг віслюк.", new DateTime(2010, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.6999999999999993, 1, "www.shrekMovieTrailerUrl.com", "Mr Producer", new DateTime(2000, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 },
                    { 2, 16, "USA", "Чувачок потрапив на корабель, корабель затонув чувачку сподобалась дівчина, там ще була та сцена на кораблі, і потім він затонув ніби.", new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0999999999999996, 2, "www.TitanicMovieTrailerUrl.com", "Mr Producer", new DateTime(1995, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 },
                    { 3, 20, "USA", "Борат стає інтервью'єром і напрвляється в Сполучені Штати щоб зустрітися з Памелою Андерсон, по дорозі розкидуючись смішнулічками.", new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0, 3, "www.BoratMovieTrailerUrl.com", "Mr Producer", new DateTime(2006, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 },
                    { 4, 16, "USA", "Невдаха Джим Кері знаходить маску на березі моря і вона фіксить всі його проблеми.", new DateTime(2015, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.0999999999999996, 4, "www.MaskMovieTrailerUrl.com", "Mr Producer", new DateTime(1999, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 },
                    { 5, 3, "USA", "Божевільна стара черепаха, вибирає по приколу ведмідя-офіціанта в якості воїна ящірки, і він стає ним за 2 дня, знецінюючи працю інших.", new DateTime(2014, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, 5, "www.shrekKungFuTrailerUrl.com", "Mr Producer", new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 },
                    { 6, 17, "USA", "Якісь сині трьох метрові створіння, шось там роблять, я не знаю бо не дивився.", new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0999999999999996, 6, "www.AvatarMovieTrailerUrl.com", "Mr Producer", new DateTime(2009, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Seanses",
                columns: new[] { "Id", "HallId", "MovieId", "PriceId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 2, 2, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "HallId", "Row", "SeatNumber", "SeatTypeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2 },
                    { 2, 1, 1, 2, 2 },
                    { 3, 1, 1, 3, 4 },
                    { 4, 1, 1, 4, 4 },
                    { 5, 1, 1, 5, 2 },
                    { 6, 1, 1, 6, 2 },
                    { 7, 1, 2, 1, 1 },
                    { 8, 1, 2, 2, 1 },
                    { 9, 1, 2, 3, 4 },
                    { 10, 1, 2, 4, 4 },
                    { 11, 1, 2, 5, 1 },
                    { 12, 1, 2, 6, 1 },
                    { 13, 1, 3, 1, 3 },
                    { 14, 1, 3, 2, 3 },
                    { 15, 1, 3, 3, 3 },
                    { 16, 1, 3, 4, 3 },
                    { 17, 1, 3, 5, 3 },
                    { 18, 1, 3, 6, 3 },
                    { 19, 1, 3, 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "Id", "AvatarUrl", "UserId" },
                values: new object[,]
                {
                    { 1, "", 1 },
                    { 2, "", 2 },
                    { 3, "", 3 },
                    { 4, "", 4 },
                    { 5, "", 5 },
                    { 6, "", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserDetailsId",
                table: "Favourites",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_MovieId",
                table: "MovieDetails",
                column: "MovieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieId",
                table: "MovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieTypeId",
                table: "Movies",
                column: "MovieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PromocodeId",
                table: "Purchase",
                column: "PromocodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_UserDetailsId",
                table: "Purchase",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieDetailsId",
                table: "Reviews",
                column: "MovieDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserDetailsId",
                table: "Reviews",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanses_HallId",
                table: "Seanses",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanses_MovieId",
                table: "Seanses",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanses_PriceId",
                table: "Seanses",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PurchaseId",
                table: "Tickets",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeanseId",
                table: "Tickets",
                column: "SeanseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MovieDetails");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Seanses");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MovieTypes");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
