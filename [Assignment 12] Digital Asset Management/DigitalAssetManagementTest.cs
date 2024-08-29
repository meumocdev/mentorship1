using System.Data;
using static DigitalAssetManagementTest.UserTests;

namespace DigitalAssetManagementTest
{
    /*    [TestClass]
        public class UnitTest1
        {
            private static User InitUserData()
            {
                var user = new User();
                user.Name = "John";
                user.Id = 1;
                user.AddDrive(new Drive { DriveId = 1, DriveName = "GoogleDrive" });
                user.AddDrive(new Drive { DriveId = 2, DriveName = "OneDrive" });
                return user;
            }

            [TestMethod]
            public void TestInitUser()
            {
                var user = new User();
                user.Name = "John";
                user.Id = 1;

                Assert.AreEqual("John", user.Name);
            }

            [TestMethod]
            public void TestInitDrive()
            {
                var drive = new Drive();
                drive.DriveId = 1;
                drive.DriveName = "Job";

                Assert.AreEqual("Job", drive.DriveName);

            }

            [TestMethod]
            public void TestInitFolder()
            {
                var folder = new Folder();
                folder.FolderId = 1;
                folder.FolderName = "abc";


                Assert.AreEqual("abc", folder.FolderName);
            }

            [TestMethod]
            public void TestInitFile()
            {
                var file = new File();
                file.FileId = 1;
                file.FileName = "abc.text";
                Assert.AreEqual("abc.text", file.FileName);
            }


            [TestMethod]
            public void TestUserCanAddDrive()
            {
                var user = new User();
                Drive drive = new Drive() { DriveId=3,DriveName="Cloud"};
                user.AddDrive(drive);
                Assert.AreEqual(3,drive.DriveId);
            }

            [TestMethod]
            public void TestUserCanRemoveDrive() 
            { 
                var user = new User();
                Drive drive = new Drive() { DriveId = 3, DriveName = "Cloud" };
                user.RemoveDrive(drive);
                Assert.AreNotEqual(2,user.Drives.Count);

            }

            [TestMethod]
            public void TestUserHasMultipleDrives()
            {
                User user = InitUserData();

                Assert.AreEqual(2, user.Drives.Count);

            }

            [TestMethod]
            public void TestOneDriveHasMultipleFolders()
            {
                var drive = new Drive { DriveId = 1, DriveName = "GoogleDrive" };

                Assert.AreEqual(2, drive.Folders.Count);
            }

            [TestMethod]
            public void TestOneDriveHasMultipleFiles()
            {
                var drive = new Drive { DriveId = 1, DriveName = "GoogleDrive" };
    *//*            drive.AddFile(new File { FileId = 1, FileName = "mentorship.pdf" });
                drive.AddFile(new File { FileId = 2, FileName = "daovo.docx" });*//*

                Assert.AreEqual(2, drive.Files.Count);
                var count = drive.Files.Count(e => e.FileName.Equals("daovo.docx"));
                Assert.AreEqual(1, count);
            }

            [TestMethod]
            public void TestUserHasMultipleDrivesWithFolders()
            {
                var user = new User();
                user.Name = "John";
                user.Id = 1;
                var drive = new Drive { DriveId = 1, DriveName = "GoogleDrive" };
    *//*            drive.AddFolder(new Folder { FolderId = 1, FolderName = "mentorship2024" });
                drive.AddFolder(new Folder { FolderId = 2, FolderName = "bbv" });*//*
                user.AddDrive(drive);

                var drive2 = new Drive { DriveId = 2, DriveName = "OneDrive" };
    *//*            drive2.AddFolder(new Folder { FolderId = 1, FolderName = "mentorship2024" });
                drive2.AddFolder(new Folder { FolderId = 2, FolderName = "bbv" });*//*
                user.AddDrive(drive2);

                Assert.AreEqual(2, user.Drives.Count);
                Assert.AreEqual(2, user.Drives[0].Folders.Count);
                Assert.AreEqual(2, user.Drives[1].Folders.Count);
            }

            [TestMethod]
            public void TestFolderHasMultipleFilesAndSubfolders()
            {
                var user = InitUserData();

    *//*            user.Drives[0].AddFolder(new Folder { FolderId = 2, FolderName = "internship" });
                user.Drives[0].AddFolder(new Folder { FolderId = 1, FolderName = "bbv" });
                user.Drives[0].AddFile(new File { FileId = 1, FileName = "mentorship.pdf" });*//*

                Assert.AreEqual(2, user.Drives[0].Folders.Count);
                Assert.AreEqual(1, user.Drives[0].Files.Count);


            }

            [TestMethod]
            public void TestFolderHasMultpleSubFolders()
            {
                var user = InitUserData();
    *//*
                user.Drives[0].AddFolder(new Folder { FolderId = 2, FolderName = "internship" });
                Folder folder = new Folder { FolderId = 1, FolderName = "bbv" };
                user.Drives[0].AddFolder(folder);
                user.Drives[0].AddFile(new File { FileId = 1, FileName = "mentorship.pdf" });*//*

                Folder folderWorking = new Folder { FolderId = 1, FolderName = "working" };
    *//*            folder.AddFolder(folderWorking);
                folder.AddFolder(new Folder { FolderId = 1, FolderName = "projects" });
                folder.AddFolder(new Folder { FolderId = 1, FolderName = "design" });
                folder.AddFolder(new Folder { FolderId = 1, FolderName = "training" });*/

    /*            Assert.AreEqual(4, folder.Folders.Count);*//*

                folderWorking.AddFile(new File { FileId = 1, FileName = "sample.sql" });

                Assert.AreEqual(1, folderWorking.Files.Count);
            }

            [TestMethod]
            public void TestHasOwnerDriveRightPermission()
            {
                User user = InitUserData();

                Assert.IsTrue(user.HasOwnerPermission(driveId: 1));

            }

            [TestMethod]
            public void TestHasNoOwnerDriveRightPermission()
            {
                User user = InitUserData();

                Assert.IsFalse(user.HasOwnerPermission(driveId: 3));

            }

            [TestMethod]
            public void TestInviteUserToDrive()
            {
                User user = InitUserData();
                User guestUser = new User
                {
                    Name = "ChiTai",
                    Id = 3
                };

                Drive drive = new Drive { DriveId = 3, DriveName = "DropBox" };
                user.AddDrive(drive);

                var drivePermission = new DrivePermission();
                drivePermission.Invite(guestUser.Id, driveId: 3, permission: "ADMIN");

                Assert.IsTrue(drivePermission.HasAdminPermission(3, driveId: 3));
            }

            [TestMethod]
            public void TestRemoveUserToDrive()
            {
                User user = InitUserData();
                User guestUser = new User
                {
                    Name = "ChiTai",
                    Id = 3
                };

                Drive drive = new Drive { DriveId = 3, DriveName = "DropBox" };
                user.AddDrive(drive);

                var drivePermission = new DrivePermission();
                drivePermission.Invite(guestUser.Id, driveId: 3, permission: "ADMIN");

                drivePermission.RemovePermission(guestUser.Id, driveId: 3, permission: "ADMIN");
                Assert.IsFalse(drivePermission.HasAdminPermission(3,3));
            }

            [TestMethod]
            public void TestInviteUserToFolder()
            {
                User user = InitUserData();
                User guestUser = new User
                {
                    Name = "ChiTai",
                    Id = 3
                };

                Folder folder = new Folder { FolderId = 1,FolderName="aaa" };


                Drive drive = new Drive { DriveId = 3, DriveName = "DropBox" };
                user.AddDrive(drive);
    *//*            drive.AddFolder(folder);
    *//*
                var folderPermission = new FolderPermission();
                folderPermission.Invite(guestUser.Id, folderId: 1, permission: "ADMIN");

                Assert.IsTrue(folderPermission.HasAdminPermission(3, 1));
            }

            [TestMethod]
            public void TestRemoveUserToFolder()
            {
                User user = InitUserData();
                User guestUser = new User
                {
                    Name = "ChiTai",
                    Id = 3
                };

                Drive drive = new Drive { DriveId = 3, DriveName = "DropBox" };
                Folder folder = new Folder { FolderId = 1, FolderName = "aaa" };
                user.AddDrive(drive);
    *//*            drive.AddFolder(folder);
    *//*            var drivePermission = new DrivePermission();
                drivePermission.Invite(guestUser.Id, folder.FolderId, permission: "ADMIN");

                drivePermission.RemovePermission(guestUser.Id, folder.FolderId, permission: "ADMIN");
                Assert.IsFalse(drivePermission.HasAdminPermission(3, 1));
            }

            [TestMethod]
            public void TestInviteUserToFile()
            {
                User user = InitUserData();
                User guestUser = new User { Name = "ChiTai", Id = 3 };

                Folder folder = new Folder { FolderId = 1, FolderName = "aaa" };
                File file = new File { FileId = 123, FileName = "document.txt" }; 
                folder.AddFile(file); 

                var filePermission = new FilePermission();
                filePermission.Invite(guestUser.Id, file.FileId, permission: "ADMIN");

                Assert.IsTrue(filePermission.HasAdminPermission(3, file.FileId)); 
            }

            [TestMethod]
            public void TestRemoveUserToFile()
            {

                User guestUser = new User { Name = "ChiTai", Id = 3 };

                Folder folder = new Folder { FolderId = 1, FolderName = "aaa" };
                File file = new File { FileId = 123, FileName = "document.txt" };
                folder.AddFile(file);

                var filePermission = new FilePermission();
                filePermission.Invite(guestUser.Id, file.FileId, permission: "ADMIN");

                filePermission.RemovePermission(guestUser.Id, file.FileId, permission: "ADMIN");
                Assert.IsFalse(filePermission.HasAdminPermission(3, file.FileId));
            }
        }*/

    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void IsAdmin_ShouldReturnTrue_WhenUserIsAdmin()
        {
            // Arrange
            var user = new User("TestUser");
            user.Permissions.Add(new Permission("Admin"));

            // Act
            bool result = user.IsAdmin();

            // Assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class FileTest
    {
        [TestMethod]
        public void GrantPermission_ShouldAddPermission_WhenUserIsGivenPermission()
        {
            // Arrange
            var user = new User("TestUser");
            var file = new File("TestFile.txt", user);
            var permission = new Permission("Read");

            // Act
            file.GrantPermission(user, permission);

            Assert.AreEqual(user.Permissions, "Read");
            // Assert
/*            Assert.IsTrue(file.Permissions.ContainsKey(user));
*/        }
    }

    public class Folder
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public Folder ParentFolder { get; set; }
        public List<Folder> SubFolders { get; private set; } = new List<Folder>();
        public List<File> Files { get; private set; } = new List<File>();
        public User CreatedBy { get; set; }

        public Dictionary<User, Permission> Permissions { get; set; }

        // Phương thức thêm thư mục con
        public void AddSubFolder(User user, Folder folder)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                SubFolders.Add(folder);
                Console.WriteLine("Folder added successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền thêm thư mục.");
            }
        }

        // Phương thức xóa thư mục con
        public void RemoveSubFolder(User user, Folder folder)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                SubFolders.Remove(folder);
                Console.WriteLine("Folder removed successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền xóa thư mục.");
            }
        }

        // Phương thức thêm tệp tin
        public void AddFile(User user, File file)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                Files.Add(file);
                Console.WriteLine("File added successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền thêm tệp tin.");
            }
        }

        // Phương thức xóa tệp tin
        public void RemoveFile(User user, File file)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                Files.Remove(file);
                Console.WriteLine("File removed successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền xóa tệp tin.");
            }
        }



        public void AddFile(File file)
        {
            Files.Add(file);
        }

        public void GrantPermission(User user, Permission permission)
        {
            // Cấp quyền cho thư mục hiện tại
            Permissions[user] = permission;

            // Cấp quyền cho tất cả thư mục con
            foreach (var subFolder in SubFolders)
            {
                subFolder.GrantPermission(user, permission);
            }

            // Cấp quyền cho tất cả tệp tin trong thư mục
            foreach (var file in Files)
            {
                file.GrantPermission(user, permission);
            }
        }

        public void RevokePermission(User user)
        {
            // Thu hồi quyền từ thư mục hiện tại
            Permissions.Remove(user);

            // Thu hồi quyền từ tất cả thư mục con
            foreach (var subFolder in SubFolders)
            {
                subFolder.RevokePermission(user);
            }

            // Thu hồi quyền từ tất cả tệp tin trong thư mục
            foreach (var file in Files)
            {
                file.RevokePermission(user);
            }
        }
    }

    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public Folder ParentFolder { get; set; }
        public User CreatedBy { get; set; }
        public Dictionary<User, Permission> Permissions { get; set; }
        public void GrantPermission(User user, Permission permission)
        {
            Permissions[user] = permission;
        }

        public void RevokePermission(User user)
        {
            Permissions.Remove(user);
        }

        public File(string fileName, User createdBy)
        {
            FileName = fileName;
            CreatedBy = createdBy;
        }


        /*        public void Upload(User user)
                {
                    if (user.UserId == CreatedBy.UserId || user.IsAdmin())
                    {
                        // Logic tải lên tệp tin
                        Console.WriteLine("File uploaded successfully.");
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("Bạn không có quyền tải lên tệp tin.");
                    }
                }*/

        // Phương thức xóa tệp tin
        /*        public void Delete(User user)
                {
                    if (user.UserId == CreatedBy.UserId || user.IsAdmin())
                    {
                        // Logic xóa tệp tin
                        Console.WriteLine("File deleted successfully.");
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("Bạn không có quyền xóa tệp tin.");
                    }
                }*/

    }


    public class Drive
    {
        public int DriveId { get; set; }
        public string DriveName { get; set; }

        public User CreatedBy { get; set; }
        public List<Folder> Folders { get; private set; } = new List<Folder>();
        public List<File> Files { get; private set; } = new List<File>();
        public Dictionary<User, Permission> Permissions { get; set; }

        // Phương thức cấp quyền
        public void GrantPermission(User user, Permission permission)
        {
            // Cấp quyền cho Drive hiện tại
            Permissions[user] = permission;

            // Cấp quyền cho tất cả thư mục và tệp tin trong Drive
            foreach (var folder in Folders)
            {
                folder.GrantPermission(user, permission);
            }

            foreach (var file in Files)
            {
                file.GrantPermission(user, permission);
            }
        }

        // Phương thức thu hồi quyền
        public void RevokePermission(User user)
        {
            // Thu hồi quyền từ Drive hiện tại
            Permissions.Remove(user);

            // Thu hồi quyền từ tất cả thư mục và tệp tin trong Drive
            foreach (var folder in Folders)
            {
                folder.RevokePermission(user);
            }

            foreach (var file in Files)
            {
                file.RevokePermission(user);
            }
        }

        // Phương thức thêm thư mục
        public void AddFolder(User user, Folder folder)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                Folders.Add(folder);
                Console.WriteLine("Folder added successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền thêm thư mục.");
            }
        }

        // Phương thức xóa thư mục
        public void RemoveFolder(User user, Folder folder)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                Folders.Remove(folder);
                Console.WriteLine("Folder removed successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền xóa thư mục.");
            }
        }

        // Phương thức thêm tệp tin
        public void AddFile(User user, File file)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                Files.Add(file);
                Console.WriteLine("File added successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền thêm tệp tin.");
            }
        }

        // Phương thức xóa tệp tin
        public void RemoveFile(User user, File file)
        {
            if (user.Id == CreatedBy.Id || user.IsAdmin())
            {
                Files.Remove(file);
                Console.WriteLine("File removed successfully.");
            }
            else
            {
                throw new UnauthorizedAccessException("Bạn không có quyền xóa tệp tin.");
            }
        }
    }

    public class User
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public List<Drive> Drives { get; set; } = new List<Drive>();
        public List<Permission> Permissions { get; set; } = new List<Permission>();

        

        public User(string name)
        {
            Name = name;
        }

        public void AddDrive(Drive driveInfo)
        {
            Drives.Add(driveInfo);
        }

        public void RemoveDrive(Drive drive)
        {
            Drives.Remove(drive);
        }

        public bool HasOwnerPermission(int driveId)
        {
            var userId = this.Id;
            return Drives.Any(e => e.DriveId == driveId);

        }

        public bool IsAdmin()
        {
            return Permissions.Any(Permissions => Permissions.PermissionName == "Admin");
        }

    }

    public class Permission
    {
        public int PermissionId;
        public string PermissionName;

        public Permission(string PermissionName)
        {
            this.PermissionName = PermissionName;
        }
    }
    public class PermissionService
    {
        // Phương thức cấp quyền cho Drive
        public void GrantPermission(User user, Drive drive, Permission permission)
        {
            drive.GrantPermission(user, permission);
        }

        // Phương thức thu hồi quyền từ Drive
        public void RevokePermission(User user, Drive drive)
        {
            drive.RevokePermission(user);
        }

        // Phương thức cấp quyền cho Folder
        public void GrantPermission(User user, Folder folder, Permission permission)
        {
            folder.GrantPermission(user, permission);
        }

        // Phương thức thu hồi quyền từ Folder
        public void RevokePermission(User user, Folder folder)
        {
            folder.RevokePermission(user);
        }
    }
    public enum RoleName
    {
        Admin,
        Contributor,
        Read
    }
}
