namespace DigitalAssetManagementTest
{
    [TestClass]
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
            drive.AddFolder(new Folder { FolderId = 1, FolderName = "mentorship2024" });
            drive.AddFolder(new Folder { FolderId = 2, FolderName = "bbv" });

            Assert.AreEqual(2, drive.Folders.Count);
        }

        [TestMethod]
        public void TestOneDriveHasMultipleFiles()
        {
            var drive = new Drive { DriveId = 1, DriveName = "GoogleDrive" };
            drive.AddFile(new File { FileId = 1, FileName = "mentorship.pdf" });
            drive.AddFile(new File { FileId = 2, FileName = "daovo.docx" });

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
            drive.AddFolder(new Folder { FolderId = 1, FolderName = "mentorship2024" });
            drive.AddFolder(new Folder { FolderId = 2, FolderName = "bbv" });
            user.AddDrive(drive);

            var drive2 = new Drive { DriveId = 2, DriveName = "OneDrive" };
            drive2.AddFolder(new Folder { FolderId = 1, FolderName = "mentorship2024" });
            drive2.AddFolder(new Folder { FolderId = 2, FolderName = "bbv" });
            user.AddDrive(drive2);

            Assert.AreEqual(2, user.Drives.Count);
            Assert.AreEqual(2, user.Drives[0].Folders.Count);
            Assert.AreEqual(2, user.Drives[1].Folders.Count);
        }

        [TestMethod]
        public void TestFolderHasMultipleFilesAndSubfolders()
        {
            var user = InitUserData();

            user.Drives[0].AddFolder(new Folder { FolderId = 2, FolderName = "internship" });
            user.Drives[0].AddFolder(new Folder { FolderId = 1, FolderName = "bbv" });
            user.Drives[0].AddFile(new File { FileId = 1, FileName = "mentorship.pdf" });

            Assert.AreEqual(2, user.Drives[0].Folders.Count);
            Assert.AreEqual(1, user.Drives[0].Files.Count);


        }

        [TestMethod]
        public void TestFolderHasMultpleSubFolders()
        {
            var user = InitUserData();

            user.Drives[0].AddFolder(new Folder { FolderId = 2, FolderName = "internship" });
            Folder folder = new Folder { FolderId = 1, FolderName = "bbv" };
            user.Drives[0].AddFolder(folder);
            user.Drives[0].AddFile(new File { FileId = 1, FileName = "mentorship.pdf" });

            Folder folderWorking = new Folder { FolderId = 1, FolderName = "working" };
            folder.AddFolder(folderWorking);
            folder.AddFolder(new Folder { FolderId = 1, FolderName = "projects" });
            folder.AddFolder(new Folder { FolderId = 1, FolderName = "design" });
            folder.AddFolder(new Folder { FolderId = 1, FolderName = "training" });

            Assert.AreEqual(4, folder.Folders.Count);

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
            drive.AddFolder(folder);

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
            drive.AddFolder(folder);
            var drivePermission = new DrivePermission();
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
            User user = InitUserData();
            User guestUser = new User { Name = "ChiTai", Id = 3 };

            Folder folder = new Folder { FolderId = 1, FolderName = "aaa" };
            File file = new File { FileId = 123, FileName = "document.txt" };
            folder.AddFile(file);

            var filePermission = new FilePermission();
            filePermission.Invite(guestUser.Id, file.FileId, permission: "ADMIN");

            filePermission.RemovePermission(guestUser.Id, file.FileId, permission: "ADMIN");
            Assert.IsFalse(filePermission.HasAdminPermission(3, file.FileId));
        }
    }

    public class DrivePermission
    {
        public DrivePermission()
        {
        }
        public List<DrivePermissionUser> DrivePermissionSet = new List<DrivePermissionUser>();

        public void Invite(int userId, int driveId, string permission)
        {
            DrivePermissionSet.Add(new DrivePermissionUser() { UserId = userId, DriveId = driveId, Permission = permission });

        }
        public void RemovePermission(int userId, int driveId, string permission)
        {
            var permissionsToRemove = new List<DrivePermissionUser>();
            foreach (var Permission in DrivePermissionSet)
            {
                if (Permission.UserId == userId && Permission.DriveId == driveId && Permission.Permission == permission)
                {
                    permissionsToRemove.Add(Permission);
                }
            }

            foreach (var permissionToRemove in permissionsToRemove)
            {
                DrivePermissionSet.Remove(permissionToRemove);
            }
        }

        internal bool HasAdminPermission(int userId, int driveId)
        {
            return DrivePermissionSet.Any(e => e.UserId == userId && e.DriveId == driveId && e.Permission == "ADMIN");
        }
    }

    public class DrivePermissionUser
    {
        public DrivePermissionUser()
        {
        }

        public int UserId { get; set; }
        public int DriveId { get; set; }
        public string Permission { get; set; }
    }

    public class FolderPermission
    {
        public FolderPermission()
        {
        }

        public List<FolderPermissionUser> FolderPermissionSet = new List<FolderPermissionUser>();

        public void Invite(int userId, int folderId, string permission)
        {
            FolderPermissionSet.Add(new FolderPermissionUser() { UserId = userId, FolderId = folderId, Permission = permission });
        }

        public void RemovePermission(int userId, int folderId, string permission)
        {
            var permissionsToRemove = new List<FolderPermissionUser>();
            foreach (var Permission in FolderPermissionSet)
            {
                if (Permission.UserId == userId && Permission.FolderId == folderId && Permission.Permission == permission)
                {
                    permissionsToRemove.Add(Permission);
                }
            }

            foreach (var permissionToRemove in permissionsToRemove)
            {
                FolderPermissionSet.Remove(permissionToRemove);
            }
        }

        internal bool HasAdminPermission(int userId, int folderId)
        {
            return FolderPermissionSet.Any(e => e.UserId == userId && e.FolderId == folderId && e.Permission == "ADMIN");
        }
    }

    public class FolderPermissionUser
    {
        public FolderPermissionUser()
        {
        }

        public int UserId { get; set; }
        public int FolderId { get; set; }
        public string Permission { get; set; }
    }

    public class FilePermission
    {
        public FilePermission()
        {
        }
        public List<FilePermissionUser> FilePermissionSet = new List<FilePermissionUser>();

        public void Invite(int userId, int fileId, string permission)
        {
            FilePermissionSet.Add(new FilePermissionUser() { UserId = userId, FileId = fileId, Permission = permission });
        }

        public void RemovePermission(int userId, int fileId, string permission)
        {
            var permissionsToRemove = new List<FilePermissionUser>();
            foreach (var Permission in FilePermissionSet)
            {
                if (Permission.UserId == userId && Permission.FileId == fileId && Permission.Permission == permission)
                {
                    permissionsToRemove.Add(Permission);
                }
            }

            foreach (var permissionToRemove in permissionsToRemove)
            {
                FilePermissionSet.Remove(permissionToRemove);
            }
        }

        internal bool HasAdminPermission(int userId, int fileId)
        {
            return FilePermissionSet.Any(e => e.UserId == userId && e.FileId == fileId && e.Permission == "ADMIN");
        }
    }

    public class FilePermissionUser
    {
        public FilePermissionUser()
        {
        }

        public int UserId { get; set; }
        public int FileId { get; set; }
        public string Permission { get; set; }
    }

    public class Folder
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public List<Folder> Folders { get; private set; } = new List<Folder>();
        public List<File> Files { get; private set; } = new List<File>();

        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);
        }

        public void AddFile(File file)
        {
            Files.Add(file);
        }
    }

    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
    }


    public class Drive
    {
        public int DriveId { get; set; }
        public string DriveName { get; set; }
        public List<Folder> Folders { get; private set; } = new List<Folder>();
        public List<File> Files { get; private set; } = new List<File>();

        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);
        }

        public void AddFile(File file)
        {
            Files.Add(file);
        }
    }

    public class User
    {
        public User()
        {
        }

        public string Name { get; internal set; }
        public int Id { get; internal set; }
        public List<Drive> Drives { get; set; } = new List<Drive>();

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
    }

}
