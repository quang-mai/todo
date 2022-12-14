// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Todo.DataAccess;

#nullable disable

namespace Todo.DataAccess.Migrations
{
    [DbContext(typeof(TodoContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Todo.DataAccess.Models.TodoList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Homework"
                        },
                        new
                        {
                            Id = 2,
                            Label = "House"
                        });
                });

            modelBuilder.Entity("Todo.DataAccess.Models.TodoTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .HasColumnType("text");

                    b.Property<int>("TodoListId")
                        .HasColumnType("integer");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("TodoListId");

                    b.ToTable("TodoTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Math",
                            TodoListId = 1,
                            isCompleted = false
                        },
                        new
                        {
                            Id = 2,
                            Label = "History",
                            TodoListId = 1,
                            isCompleted = false
                        },
                        new
                        {
                            Id = 3,
                            Label = "Science",
                            TodoListId = 1,
                            isCompleted = false
                        },
                        new
                        {
                            Id = 4,
                            Label = "Mow Lawn",
                            TodoListId = 2,
                            isCompleted = false
                        },
                        new
                        {
                            Id = 5,
                            Label = "Clean bathroom",
                            TodoListId = 2,
                            isCompleted = false
                        });
                });

            modelBuilder.Entity("Todo.DataAccess.Models.TodoTask", b =>
                {
                    b.HasOne("Todo.DataAccess.Models.TodoList", "TodoList")
                        .WithMany("Todos")
                        .HasForeignKey("TodoListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoList");
                });

            modelBuilder.Entity("Todo.DataAccess.Models.TodoList", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
