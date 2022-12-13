// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;
//
// namespace streaming_service
// {
//     public partial class streaming_serviceContext : DbContext
//     {
//         public streaming_serviceContext()
//         {
//         }
//
//         public streaming_serviceContext(DbContextOptions<streaming_serviceContext> options)
//             : base(options)
//         {
//         }
//
//         public virtual DbSet<Actor> Actors { get; set; } = null!;
//         public virtual DbSet<Device> Devices { get; set; } = null!;
//         public virtual DbSet<Director> Directors { get; set; } = null!;
//         public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; } = null!;
//         public virtual DbSet<FilmsWithAuthor> FilmsWithAuthors { get; set; } = null!;
//         public virtual DbSet<FilmsWithAuthors2> FilmsWithAuthors2s { get; set; } = null!;
//         public virtual DbSet<Genre> Genres { get; set; } = null!;
//         public virtual DbSet<Logger> Loggers { get; set; } = null!;
//         public virtual DbSet<Movie> Movies { get; set; } = null!;
//         public virtual DbSet<Payment> Payments { get; set; } = null!;
//         public virtual DbSet<Plan> Plans { get; set; } = null!;
//         public virtual DbSet<ReiewsViewTmp> ReiewsViewTmps { get; set; } = null!;
//         public virtual DbSet<Review> Reviews { get; set; } = null!;
//         public virtual DbSet<ReviewsView> ReviewsViews { get; set; } = null!;
//         public virtual DbSet<Role> Roles { get; set; } = null!;
//         public virtual DbSet<Session> Sessions { get; set; } = null!;
//         public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
//         public virtual DbSet<User> Users { get; set; } = null!;
//
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseMySql("server=localhost;user=root;database=streaming_service", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
//             }
//         }
//
//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
//                 .HasCharSet("utf8mb4");
//
//             modelBuilder.Entity<Actor>(entity =>
//             {
//                 entity.HasIndex(e => new { e.ActorName, e.ActorSurname }, "actors_actor_name_surname_idx");
//
//                 entity.Property(e => e.ActorId).HasColumnName("actor_id");
//
//                 entity.Property(e => e.ActorName).HasColumnName("actor_name");
//
//                 entity.Property(e => e.ActorSurname)
//                     .HasMaxLength(45)
//                     .HasColumnName("actor_surname");
//
//                 entity.Property(e => e.DateOfBirth)
//                     .HasColumnType("datetime")
//                     .HasColumnName("date_of_birth");
//
//                 entity.Property(e => e.Gender)
//                     .HasColumnType("enum('male','female','not_binary')")
//                     .HasColumnName("gender");
//
//                 entity.HasMany(d => d.Movies)
//                     .WithMany(p => p.Actors)
//                     .UsingEntity<Dictionary<string, object>>(
//                         "MovieHasActor",
//                         l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK_movieactor_id"),
//                         r => r.HasOne<Actor>().WithMany().HasForeignKey("ActorId").HasConstraintName("FK_actor_id"),
//                         j =>
//                         {
//                             j.HasKey("ActorId", "MovieId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
//
//                             j.ToTable("movie_has_actor");
//
//                             j.HasIndex(new[] { "MovieId" }, "FK_movieactor_id");
//
//                             j.IndexerProperty<uint>("ActorId").HasColumnName("actor_id");
//
//                             j.IndexerProperty<uint>("MovieId").HasColumnName("movie_id");
//                         });
//             });
//
//             modelBuilder.Entity<Device>(entity =>
//             {
//                 entity.Property(e => e.DeviceId).HasColumnName("device_id");
//
//                 entity.Property(e => e.DeviceName)
//                     .HasMaxLength(45)
//                     .HasColumnName("device_name");
//
//                 entity.Property(e => e.DeviceType)
//                     .HasColumnType("enum('tv','pc','smartphone')")
//                     .HasColumnName("device_type");
//             });
//
//             modelBuilder.Entity<Director>(entity =>
//             {
//                 entity.HasIndex(e => new { e.DirectorName, e.DirectorSurname }, "directors_director_name_surname_idx");
//
//                 entity.Property(e => e.DirectorId).HasColumnName("director_id");
//
//                 entity.Property(e => e.DateOfBirth)
//                     .HasColumnType("datetime")
//                     .HasColumnName("date_of_birth");
//
//                 entity.Property(e => e.DirectorName).HasColumnName("director_name");
//
//                 entity.Property(e => e.DirectorSurname)
//                     .HasMaxLength(45)
//                     .HasColumnName("director_surname");
//
//                 entity.Property(e => e.Gender)
//                     .HasColumnType("enum('male','female','not_binary')")
//                     .HasColumnName("gender");
//
//                 entity.HasMany(d => d.Movies)
//                     .WithMany(p => p.Directors)
//                     .UsingEntity<Dictionary<string, object>>(
//                         "MovieHasDirector",
//                         l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK_moviedirector_id"),
//                         r => r.HasOne<Director>().WithMany().HasForeignKey("DirectorId").HasConstraintName("FK_director_id"),
//                         j =>
//                         {
//                             j.HasKey("DirectorId", "MovieId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
//
//                             j.ToTable("movie_has_director");
//
//                             j.HasIndex(new[] { "MovieId" }, "FK_moviedirector_id");
//
//                             j.IndexerProperty<uint>("DirectorId").HasColumnName("director_id");
//
//                             j.IndexerProperty<uint>("MovieId").HasColumnName("movie_id");
//                         });
//             });
//
//             modelBuilder.Entity<DjangoMigration>(entity =>
//             {
//                 entity.ToTable("django_migrations");
//
//                 entity.Property(e => e.Id).HasColumnName("id");
//
//                 entity.Property(e => e.App)
//                     .HasMaxLength(255)
//                     .HasColumnName("app");
//
//                 entity.Property(e => e.Applied)
//                     .HasMaxLength(6)
//                     .HasColumnName("applied");
//
//                 entity.Property(e => e.Name)
//                     .HasMaxLength(255)
//                     .HasColumnName("name");
//             });
//
//             modelBuilder.Entity<FilmsWithAuthor>(entity =>
//             {
//                 entity.HasNoKey();
//
//                 entity.ToView("films_with_authors");
//
//                 entity.Property(e => e.ActorNames)
//                     .HasColumnType("text")
//                     .HasColumnName("actor_names");
//
//                 entity.Property(e => e.ActorSurnames)
//                     .HasColumnType("text")
//                     .HasColumnName("actor_surnames");
//
//                 entity.Property(e => e.MovieId).HasColumnName("movie_id");
//
//                 entity.Property(e => e.MovieName)
//                     .HasMaxLength(255)
//                     .HasColumnName("movie_name");
//             });
//
//             modelBuilder.Entity<FilmsWithAuthors2>(entity =>
//             {
//                 entity.HasNoKey();
//
//                 entity.ToView("films_with_authors2");
//
//                 entity.Property(e => e.ActorNames)
//                     .HasColumnType("text")
//                     .HasColumnName("actor_names");
//
//                 entity.Property(e => e.ActorSurnames)
//                     .HasColumnType("text")
//                     .HasColumnName("actor_surnames");
//
//                 entity.Property(e => e.MovieId).HasColumnName("movie_id");
//
//                 entity.Property(e => e.MovieName)
//                     .HasMaxLength(255)
//                     .HasColumnName("movie_name");
//             });
//
//             modelBuilder.Entity<Genre>(entity =>
//             {
//                 entity.HasIndex(e => e.GenreName, "genres_genre_name_idx");
//
//                 entity.Property(e => e.GenreId).HasColumnName("genre_id");
//
//                 entity.Property(e => e.GenreName).HasColumnName("genre_name");
//
//                 entity.HasMany(d => d.Movies)
//                     .WithMany(p => p.Genres)
//                     .UsingEntity<Dictionary<string, object>>(
//                         "MovieHasGenre",
//                         l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK_moviegenre_id"),
//                         r => r.HasOne<Genre>().WithMany().HasForeignKey("GenreId").HasConstraintName("FK_genre_id"),
//                         j =>
//                         {
//                             j.HasKey("GenreId", "MovieId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
//
//                             j.ToTable("movie_has_genre");
//
//                             j.HasIndex(new[] { "MovieId" }, "FK_moviegenre_id");
//
//                             j.IndexerProperty<uint>("GenreId").HasColumnName("genre_id");
//
//                             j.IndexerProperty<uint>("MovieId").HasColumnName("movie_id");
//                         });
//             });
//
//             modelBuilder.Entity<Logger>(entity =>
//             {
//                 entity.ToTable("logger");
//
//                 entity.HasIndex(e => e.UserId, "user_id");
//
//                 entity.Property(e => e.LoggerId).HasColumnName("logger_id");
//
//                 entity.Property(e => e.Action)
//                     .HasColumnType("enum('create','read','update','delete')")
//                     .HasColumnName("action");
//
//                 entity.Property(e => e.ActionCategory)
//                     .HasColumnType("enum('session','payment','subscription','plan','director','actor','movie','genre','device','user')")
//                     .HasColumnName("action_category");
//
//                 entity.Property(e => e.Time)
//                     .HasColumnType("datetime")
//                     .HasColumnName("time");
//
//                 entity.Property(e => e.UserId).HasColumnName("user_id");
//
//                 entity.HasOne(d => d.User)
//                     .WithMany(p => p.Loggers)
//                     .HasForeignKey(d => d.UserId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("logger_ibfk_1");
//             });
//
//             modelBuilder.Entity<Movie>(entity =>
//             {
//                 entity.ToTable("movies");
//
//                 entity.HasIndex(e => e.MovieName, "movies_movie_name_idx");
//
//                 entity.Property(e => e.MovieId).HasColumnName("movie_id");
//
//                 entity.Property(e => e.AgeRestriction).HasColumnName("age_restriction");
//
//                 entity.Property(e => e.Description)
//                     .HasMaxLength(100)
//                     .HasColumnName("description");
//
//                 entity.Property(e => e.MovieName).HasColumnName("movie_name");
//
//                 entity.Property(e => e.Rating)
//                     .HasColumnType("double unsigned")
//                     .HasColumnName("rating");
//
//                 entity.Property(e => e.SubtitlesAvailable).HasColumnName("subtitles_available");
//
//                 entity.Property(e => e.Time)
//                     .HasColumnType("time")
//                     .HasColumnName("time");
//
//                 entity.Property(e => e.Year)
//                     .HasColumnType("year")
//                     .HasColumnName("year");
//             });
//
//             modelBuilder.Entity<Payment>(entity =>
//             {
//                 entity.HasIndex(e => e.UserId, "user_id");
//
//                 entity.Property(e => e.PaymentId).HasColumnName("payment_id");
//
//                 entity.Property(e => e.PaymentDate)
//                     .HasColumnType("datetime")
//                     .HasColumnName("payment_date");
//
//                 entity.Property(e => e.PaymentMethod)
//                     .HasMaxLength(45)
//                     .HasColumnName("payment_method");
//
//                 entity.Property(e => e.PaymentStatus)
//                     .HasColumnType("enum('successful','failed','pending')")
//                     .HasColumnName("payment_status");
//
//                 entity.Property(e => e.TotalAmount)
//                     .HasColumnType("double unsigned")
//                     .HasColumnName("total_amount");
//
//                 entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
//
//                 entity.Property(e => e.UserId).HasColumnName("user_id");
//
//                 entity.HasOne(d => d.User)
//                     .WithMany(p => p.Payments)
//                     .HasForeignKey(d => d.UserId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("payments_ibfk_1");
//             });
//
//             modelBuilder.Entity<Plan>(entity =>
//             {
//                 entity.Property(e => e.PlanId).HasColumnName("plan_id");
//
//                 entity.Property(e => e.BaseRate).HasColumnName("base_rate");
//
//                 entity.Property(e => e.DurationMonths).HasColumnName("duration_months");
//
//                 entity.Property(e => e.PlanDescription)
//                     .HasMaxLength(250)
//                     .HasColumnName("plan_description");
//
//                 entity.Property(e => e.PlanName)
//                     .HasMaxLength(50)
//                     .HasColumnName("plan_name");
//             });
//
//             modelBuilder.Entity<ReiewsViewTmp>(entity =>
//             {
//                 entity.HasNoKey();
//
//                 entity.ToView("reiews_view_tmp");
//
//                 entity.Property(e => e.Author)
//                     .HasMaxLength(50)
//                     .HasColumnName("author");
//
//                 entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
//
//                 entity.Property(e => e.ReviewName)
//                     .HasMaxLength(45)
//                     .HasColumnName("review_name");
//
//                 entity.Property(e => e.ReviewText)
//                     .HasMaxLength(255)
//                     .HasColumnName("review_text");
//             });
//
//             modelBuilder.Entity<Review>(entity =>
//             {
//                 entity.ToTable("reviews");
//
//                 entity.HasIndex(e => e.MovieId, "FK_moviereview_id");
//
//                 entity.HasIndex(e => e.AuthorId, "author_id");
//
//                 entity.HasIndex(e => e.ModeratorId, "moderator_id");
//
//                 entity.Property(e => e.ReviewId).HasColumnName("review_id");
//
//                 entity.Property(e => e.AuthorId).HasColumnName("author_id");
//
//                 entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");
//
//                 entity.Property(e => e.MovieId).HasColumnName("movie_id");
//
//                 entity.Property(e => e.ReviewName)
//                     .HasMaxLength(45)
//                     .HasColumnName("review_name");
//
//                 entity.Property(e => e.ReviewText)
//                     .HasMaxLength(255)
//                     .HasColumnName("review_text");
//
//                 entity.HasOne(d => d.Author)
//                     .WithMany(p => p.ReviewAuthors)
//                     .HasForeignKey(d => d.AuthorId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("reviews_ibfk_1");
//
//                 entity.HasOne(d => d.Moderator)
//                     .WithMany(p => p.ReviewModerators)
//                     .HasForeignKey(d => d.ModeratorId)
//                     .OnDelete(DeleteBehavior.ClientSetNull)
//                     .HasConstraintName("reviews_ibfk_2");
//
//                 entity.HasOne(d => d.Movie)
//                     .WithMany(p => p.Reviews)
//                     .HasForeignKey(d => d.MovieId)
//                     .HasConstraintName("FK_moviereview_id");
//             });
//
//             modelBuilder.Entity<ReviewsView>(entity =>
//             {
//                 entity.HasNoKey();
//
//                 entity.ToView("reviews_view");
//
//                 entity.Property(e => e.Author)
//                     .HasMaxLength(50)
//                     .HasColumnName("author");
//
//                 entity.Property(e => e.Moderator)
//                     .HasMaxLength(50)
//                     .HasColumnName("moderator");
//
//                 entity.Property(e => e.ReviewName)
//                     .HasMaxLength(45)
//                     .HasColumnName("review_name");
//
//                 entity.Property(e => e.ReviewText)
//                     .HasMaxLength(255)
//                     .HasColumnName("review_text");
//             });
//
//             modelBuilder.Entity<Role>(entity =>
//             {
//                 entity.Property(e => e.RoleId).HasColumnName("role_id");
//
//                 entity.Property(e => e.RoleName)
//                     .HasMaxLength(50)
//                     .HasColumnName("role_name");
//             });
//
//             modelBuilder.Entity<Session>(entity =>
//             {
//                 entity.HasIndex(e => e.DeviceId, "FK_device_id");
//
//                 entity.Property(e => e.SessionId).HasColumnName("session_id");
//
//                 entity.Property(e => e.DeviceId).HasColumnName("device_id");
//
//                 entity.Property(e => e.EndTime)
//                     .HasColumnType("datetime")
//                     .HasColumnName("end_time");
//
//                 entity.Property(e => e.StartTime)
//                     .HasColumnType("datetime")
//                     .HasColumnName("start_time");
//
//                 entity.Property(e => e.UserId).HasColumnName("user_id");
//
//                 entity.HasOne(d => d.Device)
//                     .WithMany(p => p.Sessions)
//                     .HasForeignKey(d => d.DeviceId)
//                     .HasConstraintName("FK_device_id");
//
//                 entity.HasMany(d => d.Movies)
//                     .WithMany(p => p.Sessions)
//                     .UsingEntity<Dictionary<string, object>>(
//                         "SessionsHasMovie",
//                         l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK_movie_id"),
//                         r => r.HasOne<Session>().WithMany().HasForeignKey("SessionId").HasConstraintName("FK_session_id"),
//                         j =>
//                         {
//                             j.HasKey("SessionId", "MovieId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
//
//                             j.ToTable("sessions_has_movie");
//
//                             j.HasIndex(new[] { "MovieId" }, "FK_movie_id");
//
//                             j.IndexerProperty<uint>("SessionId").HasColumnName("session_id");
//
//                             j.IndexerProperty<uint>("MovieId").HasColumnName("movie_id");
//                         });
//             });
//
//             modelBuilder.Entity<Subscription>(entity =>
//             {
//                 entity.HasIndex(e => e.PlanId, "FK_plan_id");
//
//                 entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");
//
//                 entity.Property(e => e.EndDate)
//                     .HasColumnType("datetime")
//                     .HasColumnName("end_date");
//
//                 entity.Property(e => e.IsActive).HasColumnName("is_active");
//
//                 entity.Property(e => e.PlanId).HasColumnName("plan_id");
//
//                 entity.Property(e => e.StartDate)
//                     .HasColumnType("datetime")
//                     .HasColumnName("start_date");
//
//                 entity.HasOne(d => d.Plan)
//                     .WithMany(p => p.Subscriptions)
//                     .HasForeignKey(d => d.PlanId)
//                     .HasConstraintName("FK_plan_id");
//             });
//
//             modelBuilder.Entity<User>(entity =>
//             {
//                 entity.HasIndex(e => e.RoleId, "FK_role_id");
//
//                 entity.HasIndex(e => e.SubscriptionId, "FK_subscription_id");
//
//                 entity.HasIndex(e => e.Email, "email")
//                     .IsUnique();
//
//                 entity.Property(e => e.UserId).HasColumnName("user_id");
//
//                 entity.Property(e => e.Age).HasColumnName("age");
//
//                 entity.Property(e => e.Balance)
//                     .HasColumnType("double unsigned")
//                     .HasColumnName("balance");
//
//                 entity.Property(e => e.Email)
//                     .HasMaxLength(50)
//                     .HasColumnName("email");
//
//                 entity.Property(e => e.Gender)
//                     .HasColumnType("enum('male','female','not_binary')")
//                     .HasColumnName("gender");
//
//                 entity.Property(e => e.JoinedDate)
//                     .HasColumnType("datetime")
//                     .HasColumnName("joined_date");
//
//                 entity.Property(e => e.Password)
//                     .HasMaxLength(50)
//                     .HasColumnName("password");
//
//                 entity.Property(e => e.RoleId).HasColumnName("role_id");
//
//                 entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");
//
//                 entity.Property(e => e.Username)
//                     .HasMaxLength(50)
//                     .HasColumnName("username");
//
//                 entity.HasOne(d => d.Role)
//                     .WithMany(p => p.Users)
//                     .HasForeignKey(d => d.RoleId)
//                     .HasConstraintName("FK_role_id");
//
//                 entity.HasOne(d => d.Subscription)
//                     .WithMany(p => p.Users)
//                     .HasForeignKey(d => d.SubscriptionId)
//                     .HasConstraintName("FK_subscription_id");
//             });
//
//             OnModelCreatingPartial(modelBuilder);
//         }
//
//         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//     }
// }
