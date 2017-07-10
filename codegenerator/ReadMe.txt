Please refer to "How to setup a new DAL Project.docx" on how to use and setup the EFCodeGenerator project.

Run script to Scaffold DB:
Scaffold-DbContext "Server=localhost;Database=erc;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Project PAS.ResourceCenter.Library.DataAccess -Force
