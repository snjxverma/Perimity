using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Perimity.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_ScannedBy",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AspNetUsers_UserId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_OTPVerification_AspNetUsers_UserId",
                table: "OTPVerification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OTPVerification",
                table: "OTPVerification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "OTPVerification",
                newName: "OTPVerifications");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_OTPVerification_UserId",
                table: "OTPVerifications",
                newName: "IX_OTPVerifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ScannedBy",
                table: "Attendances",
                newName: "IX_Attendances_ScannedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OTPVerifications",
                table: "OTPVerifications",
                column: "OTPId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_ScannedBy",
                table: "Attendances",
                column: "ScannedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OTPVerifications_AspNetUsers_UserId",
                table: "OTPVerifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_ScannedBy",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_UserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_OTPVerifications_AspNetUsers_UserId",
                table: "OTPVerifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OTPVerifications",
                table: "OTPVerifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "OTPVerifications",
                newName: "OTPVerification");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_OTPVerifications_UserId",
                table: "OTPVerification",
                newName: "IX_OTPVerification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ScannedBy",
                table: "Attendance",
                newName: "IX_Attendance_ScannedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OTPVerification",
                table: "OTPVerification",
                column: "OTPId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_ScannedBy",
                table: "Attendance",
                column: "ScannedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AspNetUsers_UserId",
                table: "Attendance",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OTPVerification_AspNetUsers_UserId",
                table: "OTPVerification",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
