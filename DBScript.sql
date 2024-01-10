USE [SUSSBooking]
GO
/****** Object:  Table [dbo].[CounsellingMaster]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CounsellingMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[RouteParams] [varchar](50) NULL,
 CONSTRAINT [PK_CounsellingMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormD]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PrefMobileNo] [nvarchar](10) NULL,
	[PrefEmailAddress] [nvarchar](50) NULL,
	[JobStatus] [nvarchar](50) NULL,
	[CompanyWorking] [varchar](max) NULL,
	[EmergencyContactPerson] [nvarchar](50) NULL,
	[EmergencyContactNo] [nvarchar](10) NULL,
	[EmergencyContactEmailID] [varchar](50) NULL,
	[RelationwithClint] [nvarchar](500) NULL,
	[CounsellingMasterID] [int] NULL,
 CONSTRAINT [PK_tbl_Registration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormM]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgreementSessRecorded] [bit] NULL,
	[ACKConfidSessRecorded] [bit] NULL,
	[UserID] [int] NULL,
	[CounsellingMasterID] [int] NULL,
 CONSTRAINT [PK_FormM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormN]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AgreementRuleCoaching] [bit] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_FormN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormO]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AnswertoQuestion] [nvarchar](50) NULL,
 CONSTRAINT [PK_FormO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormStatus]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[FormID] [int] NULL,
	[CounsellingID] [int] NULL,
	[FormType] [nvarchar](50) NULL,
	[StepNumber] [int] NULL,
	[IsCompleted] [bit] NULL,
	[Timestamp] [datetime] NULL,
 CONSTRAINT [PK__FormStat__C8EE20439D008AB4] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusMaster]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusMaster](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Booking]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Timestamp] [datetime] NULL,
	[CounsellingID] [int] NOT NULL,
	[BookingStatusID] [int] NULL,
 CONSTRAINT [PK_tbl_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_GenderMaster]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_GenderMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](6) NULL,
 CONSTRAINT [PK_tbl_GenderMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_UsersDetail]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UsersDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Gender] [int] NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[PINumber] [nvarchar](50) NULL,
	[NRICFIN] [nvarchar](50) NULL,
	[Race] [nvarchar](50) NULL,
	[Ethnicity] [nvarchar](50) NULL,
	[Religion] [nvarchar](50) NULL,
	[Nationality] [nvarchar](50) NULL,
	[MaritalStatus] [nvarchar](50) NULL,
	[HighestQualification] [nvarchar](50) NULL,
	[EnrolmentYearSem] [nvarchar](50) NULL,
	[School] [nvarchar](50) NULL,
	[StudyMode] [nvarchar](50) NULL,
	[ProgramName] [nvarchar](50) NULL,
	[ProgramCode] [nvarchar](50) NULL,
	[ProgramStatus] [nvarchar](50) NULL,
	[JoinedIntake] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](10) NULL,
	[MyEmailID] [nvarchar](50) NULL,
	[NextKin] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_UsersDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CounsellingMaster] ON 
GO
INSERT [dbo].[CounsellingMaster] ([ID], [Name], [RouteParams]) VALUES (1, N'Counselling', N'Counselling')
GO
INSERT [dbo].[CounsellingMaster] ([ID], [Name], [RouteParams]) VALUES (2, N'Dreamworks', N'Dreamworks')
GO
INSERT [dbo].[CounsellingMaster] ([ID], [Name], [RouteParams]) VALUES (3, N'Life Coaching', N'Coaching')
GO
SET IDENTITY_INSERT [dbo].[CounsellingMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[FormD] ON 
GO
INSERT [dbo].[FormD] ([ID], [UserID], [PrefMobileNo], [PrefEmailAddress], [JobStatus], [CompanyWorking], [EmergencyContactPerson], [EmergencyContactNo], [EmergencyContactEmailID], [RelationwithClint], [CounsellingMasterID]) VALUES (3102, 2, N'321345', N'testuser1@test.com', N'Yes', N'asdasd', N'asdasd', N'asdasd', N'testuser1@test.com', N'asdasd', 1)
GO
INSERT [dbo].[FormD] ([ID], [UserID], [PrefMobileNo], [PrefEmailAddress], [JobStatus], [CompanyWorking], [EmergencyContactPerson], [EmergencyContactNo], [EmergencyContactEmailID], [RelationwithClint], [CounsellingMasterID]) VALUES (3103, 2, N'321345', N'testuser1@test.com', N'Yes', N'asdasd', N'asdasd', N'asdasd', N'testuser1@test.com', N'asdasd', 2)
GO
SET IDENTITY_INSERT [dbo].[FormD] OFF
GO
SET IDENTITY_INSERT [dbo].[FormM] ON 
GO
INSERT [dbo].[FormM] ([ID], [AgreementSessRecorded], [ACKConfidSessRecorded], [UserID], [CounsellingMasterID]) VALUES (3055, 1, 1, 2, 1)
GO
INSERT [dbo].[FormM] ([ID], [AgreementSessRecorded], [ACKConfidSessRecorded], [UserID], [CounsellingMasterID]) VALUES (3056, 1, 1, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[FormM] OFF
GO
SET IDENTITY_INSERT [dbo].[FormStatus] ON 
GO
INSERT [dbo].[FormStatus] ([StatusID], [UserID], [FormID], [CounsellingID], [FormType], [StepNumber], [IsCompleted], [Timestamp]) VALUES (3200, 2, 3102, 1, N'FomrD', 1, 1, CAST(N'2024-01-10T17:42:06.243' AS DateTime))
GO
INSERT [dbo].[FormStatus] ([StatusID], [UserID], [FormID], [CounsellingID], [FormType], [StepNumber], [IsCompleted], [Timestamp]) VALUES (3201, 2, 3055, 1, N'FomrM', 2, 1, CAST(N'2024-01-10T17:42:11.160' AS DateTime))
GO
INSERT [dbo].[FormStatus] ([StatusID], [UserID], [FormID], [CounsellingID], [FormType], [StepNumber], [IsCompleted], [Timestamp]) VALUES (3202, 2, 3103, 2, N'FomrD', 1, 1, CAST(N'2024-01-10T17:48:05.233' AS DateTime))
GO
INSERT [dbo].[FormStatus] ([StatusID], [UserID], [FormID], [CounsellingID], [FormType], [StepNumber], [IsCompleted], [Timestamp]) VALUES (3203, 2, 3056, 2, N'FomrM', 2, 1, CAST(N'2024-01-10T17:48:08.717' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[FormStatus] OFF
GO
INSERT [dbo].[StatusMaster] ([ID], [Name]) VALUES (1, N'Submitted')
GO
INSERT [dbo].[StatusMaster] ([ID], [Name]) VALUES (2, N'Approved')
GO
INSERT [dbo].[StatusMaster] ([ID], [Name]) VALUES (3, N'Rejected')
GO
INSERT [dbo].[StatusMaster] ([ID], [Name]) VALUES (4, N'ReSubmitted')
GO
SET IDENTITY_INSERT [dbo].[tbl_Booking] ON 
GO
INSERT [dbo].[tbl_Booking] ([ID], [UserID], [Timestamp], [CounsellingID], [BookingStatusID]) VALUES (3089, 2, CAST(N'2024-01-10T17:42:11.160' AS DateTime), 1, 3)
GO
INSERT [dbo].[tbl_Booking] ([ID], [UserID], [Timestamp], [CounsellingID], [BookingStatusID]) VALUES (3090, 2, CAST(N'2024-01-10T17:43:42.890' AS DateTime), 1, 2)
GO
INSERT [dbo].[tbl_Booking] ([ID], [UserID], [Timestamp], [CounsellingID], [BookingStatusID]) VALUES (3091, 2, CAST(N'2024-01-10T17:48:08.717' AS DateTime), 2, 3)
GO
INSERT [dbo].[tbl_Booking] ([ID], [UserID], [Timestamp], [CounsellingID], [BookingStatusID]) VALUES (3092, 2, CAST(N'2024-01-10T17:55:01.620' AS DateTime), 2, 2)
GO
SET IDENTITY_INSERT [dbo].[tbl_Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_GenderMaster] ON 
GO
INSERT [dbo].[tbl_GenderMaster] ([ID], [Name]) VALUES (1, N'Male')
GO
INSERT [dbo].[tbl_GenderMaster] ([ID], [Name]) VALUES (2, N'Female')
GO
SET IDENTITY_INSERT [dbo].[tbl_GenderMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_UsersDetail] ON 
GO
INSERT [dbo].[tbl_UsersDetail] ([ID], [FullName], [Gender], [EmailAddress], [Password], [Status], [PINumber], [NRICFIN], [Race], [Ethnicity], [Religion], [Nationality], [MaritalStatus], [HighestQualification], [EnrolmentYearSem], [School], [StudyMode], [ProgramName], [ProgramCode], [ProgramStatus], [JoinedIntake], [MobileNo], [MyEmailID], [NextKin]) VALUES (1, N'Test User1', 1, N'testuser1@test.com', N'Test@123', 1, N'PIA6243944', N'NRCSH', N'Race1', N'Test Data', N'Islam', N'Indian', N'Yes', N'BCA', N'2010', N'XYZ', N'Online', N'XYZ', N'101', N'D1', N'MCA', N'9876540321', N'testuser1@test.com', N'TestData')
GO
INSERT [dbo].[tbl_UsersDetail] ([ID], [FullName], [Gender], [EmailAddress], [Password], [Status], [PINumber], [NRICFIN], [Race], [Ethnicity], [Religion], [Nationality], [MaritalStatus], [HighestQualification], [EnrolmentYearSem], [School], [StudyMode], [ProgramName], [ProgramCode], [ProgramStatus], [JoinedIntake], [MobileNo], [MyEmailID], [NextKin]) VALUES (2, N'Test User2', 1, N'testuser2@test.com', N'Test@123', 0, N'PIA6243943', N'NRCSH', N'Race1', N'Test Data', N'Hindu', N'Indian', N'Yes', N'BCA', N'2010', N'XYZ', N'Offline', N'XYZ', N'102', N'D1', N'MBA', N'9876540321', N'testuser2@test.com', N'TestData')
GO
INSERT [dbo].[tbl_UsersDetail] ([ID], [FullName], [Gender], [EmailAddress], [Password], [Status], [PINumber], [NRICFIN], [Race], [Ethnicity], [Religion], [Nationality], [MaritalStatus], [HighestQualification], [EnrolmentYearSem], [School], [StudyMode], [ProgramName], [ProgramCode], [ProgramStatus], [JoinedIntake], [MobileNo], [MyEmailID], [NextKin]) VALUES (3, N'Test User3', 2, N'testuser3@test.com', N'Test@123', 0, N'PIA6243942', N'NRCSH', N'Race1', N'Test Data', N'XYZ', N'Indian', N'No', N'BCA', N'2020', N'XYZ', N'Online', N'XYZ', N'102', N'D1', N'M-Tech', N'9876540321', N'testuser3@test.com', N'TestData')
GO
INSERT [dbo].[tbl_UsersDetail] ([ID], [FullName], [Gender], [EmailAddress], [Password], [Status], [PINumber], [NRICFIN], [Race], [Ethnicity], [Religion], [Nationality], [MaritalStatus], [HighestQualification], [EnrolmentYearSem], [School], [StudyMode], [ProgramName], [ProgramCode], [ProgramStatus], [JoinedIntake], [MobileNo], [MyEmailID], [NextKin]) VALUES (4, N'Test User4', 2, N'testuser4@test.com', N'Test@123', 0, N'PIA6243941', N'NRCSH', N'Race1', N'Test Data', N'XYZ', N'Indian', N'No', N'BCA', N'2020', N'XYZ', N'Online', N'XYZ', N'104', N'D1', N'MCA', N'9876540321', N'testuser4@test.com', N'TestData')
GO
INSERT [dbo].[tbl_UsersDetail] ([ID], [FullName], [Gender], [EmailAddress], [Password], [Status], [PINumber], [NRICFIN], [Race], [Ethnicity], [Religion], [Nationality], [MaritalStatus], [HighestQualification], [EnrolmentYearSem], [School], [StudyMode], [ProgramName], [ProgramCode], [ProgramStatus], [JoinedIntake], [MobileNo], [MyEmailID], [NextKin]) VALUES (5, N'Test User5', 1, N'testuser5@test.com', N'Test@123', 0, N'PIA6243940', N'NRCSH', N'Race1', N'Test Data', N'XYZ', N'Indian', N'No', N'BCA', N'2020', N'XYZ', N'Online', N'XYZ', N'105', N'D1', N'MVA', N'9876540321', N'testuser5@test.com', N'TestData')
GO
SET IDENTITY_INSERT [dbo].[tbl_UsersDetail] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_FormStatus]    Script Date: 10/1/2024 6:18:41 pm ******/
ALTER TABLE [dbo].[FormStatus] ADD  CONSTRAINT [UQ_FormStatus] UNIQUE NONCLUSTERED 
(
	[FormType] ASC,
	[UserID] ASC,
	[FormID] ASC,
	[CounsellingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_UsersDetail] ADD  CONSTRAINT [DF_tbl_UsersDetail_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[FormD]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Registration_CounsellingMaster] FOREIGN KEY([CounsellingMasterID])
REFERENCES [dbo].[CounsellingMaster] ([ID])
GO
ALTER TABLE [dbo].[FormD] CHECK CONSTRAINT [FK_tbl_Registration_CounsellingMaster]
GO
ALTER TABLE [dbo].[FormD]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Registration_tbl_UsersDetail] FOREIGN KEY([UserID])
REFERENCES [dbo].[tbl_UsersDetail] ([ID])
GO
ALTER TABLE [dbo].[FormD] CHECK CONSTRAINT [FK_tbl_Registration_tbl_UsersDetail]
GO
ALTER TABLE [dbo].[FormM]  WITH CHECK ADD  CONSTRAINT [FK_FormM_CounsellingMaster] FOREIGN KEY([CounsellingMasterID])
REFERENCES [dbo].[CounsellingMaster] ([ID])
GO
ALTER TABLE [dbo].[FormM] CHECK CONSTRAINT [FK_FormM_CounsellingMaster]
GO
ALTER TABLE [dbo].[FormM]  WITH CHECK ADD  CONSTRAINT [FK_FormM_tbl_UsersDetail] FOREIGN KEY([UserID])
REFERENCES [dbo].[tbl_UsersDetail] ([ID])
GO
ALTER TABLE [dbo].[FormM] CHECK CONSTRAINT [FK_FormM_tbl_UsersDetail]
GO
ALTER TABLE [dbo].[FormN]  WITH CHECK ADD  CONSTRAINT [FK_FormN_tbl_UsersDetail] FOREIGN KEY([UserID])
REFERENCES [dbo].[tbl_UsersDetail] ([ID])
GO
ALTER TABLE [dbo].[FormN] CHECK CONSTRAINT [FK_FormN_tbl_UsersDetail]
GO
ALTER TABLE [dbo].[FormO]  WITH CHECK ADD  CONSTRAINT [FK_FormO_tbl_UsersDetail] FOREIGN KEY([UserID])
REFERENCES [dbo].[tbl_UsersDetail] ([ID])
GO
ALTER TABLE [dbo].[FormO] CHECK CONSTRAINT [FK_FormO_tbl_UsersDetail]
GO
ALTER TABLE [dbo].[FormStatus]  WITH CHECK ADD  CONSTRAINT [FK_FormStatus_tbl_UsersDetail] FOREIGN KEY([CounsellingID])
REFERENCES [dbo].[CounsellingMaster] ([ID])
GO
ALTER TABLE [dbo].[FormStatus] CHECK CONSTRAINT [FK_FormStatus_tbl_UsersDetail]
GO
ALTER TABLE [dbo].[tbl_Booking]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Booking_StatusMaster] FOREIGN KEY([BookingStatusID])
REFERENCES [dbo].[StatusMaster] ([ID])
GO
ALTER TABLE [dbo].[tbl_Booking] CHECK CONSTRAINT [FK_tbl_Booking_StatusMaster]
GO
ALTER TABLE [dbo].[tbl_Booking]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Booking_tbl_Booking] FOREIGN KEY([ID])
REFERENCES [dbo].[tbl_Booking] ([ID])
GO
ALTER TABLE [dbo].[tbl_Booking] CHECK CONSTRAINT [FK_tbl_Booking_tbl_Booking]
GO
ALTER TABLE [dbo].[tbl_UsersDetail]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UsersDetail_tbl_UsersDetail] FOREIGN KEY([Gender])
REFERENCES [dbo].[tbl_UsersDetail] ([ID])
GO
ALTER TABLE [dbo].[tbl_UsersDetail] CHECK CONSTRAINT [FK_tbl_UsersDetail_tbl_UsersDetail]
GO
/****** Object:  StoredProcedure [dbo].[PROC_CheckIsUserValid]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CheckIsUserValid]
	@UserName varchar(50),
	@Password varchar(max),
	@Error_Code int = 0 OUTPUT,
	@Error_Message nvarchar(max) = '' OUTPUT
AS
BEGIN
	BEGIN TRY
	--Select * from [tbl_UsersDetail]
	Declare @ID as int
	Declare @PasswordExist as varchar(max)='N'
	set @ID = (select top(1) ID from [dbo].[tbl_UsersDetail]  where EmailAddress = @UserName);
	if isnull(@ID,'')<>''
	begin
						set @Error_Code=(Select CASE
									WHEN EXISTS(SELECT 1
												FROM tbl_UsersDetail
												WHERE EmailAddress = @UserName and
												Password=@Password) THEN 200--pending
									ELSE 401
									END AS FormExistsFlag);
						SET @Error_Message = Case When @Error_Code = 200 THEN 'Success'
									 When @Error_Code=401 Then 'PAssword is Incorrect !'
						End
	end
	else
		Begin
			SET @Error_Code = 404
			SET @Error_Message = 'User does not exist'
		End

	END TRY
		BEGIN CATCH
			SET @Error_Code = ERROR_NUMBER()  
			SET @Error_Message = ERROR_MESSAGE()  
			SELECT  'Error #'+ cast(ERROR_NUMBER() as varchar(200))+ ' - '+ERROR_MESSAGE() AS ErrorMessage;   
	END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[PROC_CheckUserIsvalidByEmailID]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CheckUserIsvalidByEmailID]
	@EmailID varchar(50),
	@CounsellingID int,
	@Error_Code int = 0 OUTPUT,
	@Error_Message nvarchar(max) = '' OUTPUT
AS
BEGIN
	BEGIN TRY
	
	Declare @UserID int
	--Declare @PasswordExist as nvarchar(max)=''
	--Declare @IsApproverPending int = 0 ;
	--Declare @IsFormExist int = 0 ;
	set @UserID = (select top(1) ID from [dbo].[tbl_UsersDetail]  where EmailAddress = @EmailID);
	if isnull(@UserID,'')<>''
	begin
	
			set @Error_Code=(Select CASE
									WHEN EXISTS(SELECT 1
												FROM tbl_Booking
												WHERE UserID=@UserID and
												(BookingStatusID=1 or BookingStatusID=4) and CounsellingID=@CounsellingID) THEN 101--Submittted,ReSubmitted
									WHEN EXISTS(SELECT 1
												FROM tbl_Booking
												WHERE UserID=@UserID and
												BookingStatusID=2 and CounsellingID=@CounsellingID) THEN 200--Approved
									WHEN EXISTS(SELECT 1
												FROM tbl_Booking
												WHERE UserID=@UserID and
												BookingStatusID=3 and CounsellingID=@CounsellingID) THEN 102--Rejected
									--WHEN EXISTS(SELECT 1
									--			FROM tbl_Booking
									--			WHERE UserID=1
									--			group by UserID
									--			having COUNT(UserID) > 0)  THEN 201--exist
							ELSE 404
						END AS FormExistsFlag);
			SET @Error_Message = Case When @Error_Code = 101 THEN 'The user has already sent the request, Please wait for the staff approver.'
									 When @Error_Code=200 Then 'Success'
									 When @Error_Code=102 Then 'Your request has been rejected, please review and Re-Submit the details.'
									 When @Error_Code=404 Then 'User does not exist'
    END 
	End
	

	END TRY
		BEGIN CATCH
			SET @Error_Code = ERROR_NUMBER()  
			SET @Error_Message = ERROR_MESSAGE()  
			SELECT  'Error #'+ cast(ERROR_NUMBER() as varchar(200))+ ' - '+ERROR_MESSAGE() AS ErrorMessage;   
	END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[PROC_CheckUserIsvalidByEmailID_backup]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CheckUserIsvalidByEmailID_backup]
	@UserName varchar(50),
	@Password varchar(max),
	@Error_Code int = 0 OUTPUT,
	@Error_Message nvarchar(max) = '' OUTPUT
AS
BEGIN
	BEGIN TRY
	
	Declare @EmailExist varchar(55)=''
	Declare @PasswordExist as varchar(max)='N'
	Declare @Approve_status as int
	set @EmailExist = (select top(1) EmailAddress from [dbo].[tbl_UsersDetail]  where EmailAddress = @UserName);

	set @Approve_status = (select top(1) UserID from [dbo].[formD]  where UserID = 
	(select top(1) ID from [dbo].[tbl_UsersDetail]  where EmailAddress = @UserName))
	--set @PasswordExist = (select top(1) Status from [dbo].[tbl_UsersDetail]  where EmailAddress = @UserName and Password=@Password)
	if isnull(@EmailExist,'')<>''
	begin
	
		if isnull(@Approve_status,'')<>'' 
		begin
			--select * from [dbo].[tbl_UsersDetail] where EmailAddress = @UserName and Password=@Password and Status=1
			SET @Error_Code = Case When @PasswordExist = 0 THEN 101 else 200 End
			SET @Error_Message = Case When @PasswordExist = 0 THEN 'The user '+ @EmailExist+' is not active, Please contact to administrator' else 'Success' End
		end
		else
			begin
			SET @Error_Code = 404
			SET @Error_Message = 'User does not exist'
				--SET @Error_Code = 401
				--SET @Error_Message = 'Password is incorrect'
			end
	end
	else
		Begin
			SET @Error_Code = 404
			SET @Error_Message = 'User does not exist'
		End

	END TRY
		BEGIN CATCH
			SET @Error_Code = ERROR_NUMBER()  
			SET @Error_Message = ERROR_MESSAGE()  
			SELECT  'Error #'+ cast(ERROR_NUMBER() as varchar(200))+ ' - '+ERROR_MESSAGE() AS ErrorMessage;   
	END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[PROC_CreateFormD]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CreateFormD]
@ID int null,
@UserID int null,
@PINumber nvarchar(50)='',
@FullName nvarchar(50)='',
@Status bit = 0,
@PrefMobileNo nvarchar(10) ,
@CounsellingID int null,
@PrefEmailAddress nvarchar(50) ,
@JobStatus nvarchar(50) ,
@CompanyWorking nvarchar(Max) ,
@EmergencyContactPerson nvarchar(50) ,
@EmergencyContactNo nvarchar(10) ,
@EmergencyContactEmailID nvarchar(50) ,
@RelationwithClint nvarchar(50),
@BookingID int null
AS
Begin
Declare @FormID int =null;
set @FormID = (Select ID from FormD where UserID=@UserID and CounsellingMasterID=@CounsellingID)
if isnull(@FormID,'')<>''
Begin
Update [FormD] set 
           [UserID]=@UserID
           ,[PrefMobileNo]=@PrefMobileNo
           ,[PrefEmailAddress]=@PrefEmailAddress
           ,[JobStatus]=@JobStatus
           ,[CompanyWorking]=@CompanyWorking
           ,[EmergencyContactPerson]=@EmergencyContactPerson
           ,[EmergencyContactNo]=@EmergencyContactNo
           ,[EmergencyContactEmailID]=@EmergencyContactEmailID
           ,[RelationwithClint]=@RelationwithClint 
		    where UserID=@UserID
Update [FormStatus] set [IsCompleted]=1 
	where FormID=@FormID and UserID=@UserID and CounsellingID=@CounsellingID

SELECT @FormID as ID
End
Else
Begin
INSERT INTO [dbo].[FormD]
           ([UserID]
           ,[PrefMobileNo]
           ,[PrefEmailAddress]
           ,[JobStatus]
           ,[CompanyWorking]
           ,[EmergencyContactPerson]
           ,[EmergencyContactNo]
           ,[EmergencyContactEmailID]
           ,[RelationwithClint],CounsellingMasterID)
     VALUES(@UserID,@PrefMobileNo,@PrefEmailAddress,@JobStatus,@CompanyWorking,@EmergencyContactPerson
		   ,@EmergencyContactNo,@EmergencyContactEmailID,@RelationwithClint,@CounsellingID)
set @FormID = (SELECT CAST(SCOPE_IDENTITY() as int))

INSERT INTO [dbo].[FormStatus]
           ([UserID]
           ,[FormID]
           ,[FormType]
           ,[StepNumber]
           ,[IsCompleted]
           ,[Timestamp]
		   ,CounsellingID)
     VALUES(@UserID,@FormID,'FomrD',1,1,getdate(),@CounsellingID)
SELECT CAST(SCOPE_IDENTITY() as int) as ID
End
End
GO
/****** Object:  StoredProcedure [dbo].[PROC_CreateFormM]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CreateFormM]
@ID int null,
@UserID int null,
@CounsellingID int null,
@FullName nvarchar(50)='',
@Status bit = 0,
@PINumber nvarchar(50)='',
@AgreementSessRecorded bit ,
@ACKConfidSessRecorded bit,
@BookingID int null
AS
Begin
Declare @FormID int =null;
set @FormID = (Select ID from FormM where UserID=@UserID and CounsellingMasterID=@CounsellingID)
if isnull(@FormID,'')<>''
Begin

	Update [FormM] set [AgreementSessRecorded]=@AgreementSessRecorded
					   ,[ACKConfidSessRecorded]=@ACKConfidSessRecorded
					   where UserID=@UserID

	Update [FormStatus] set [IsCompleted]=1 
	where FormID=@FormID and UserID=@UserID and CounsellingID=@CounsellingID
	
	INSERT INTO [dbo].[tbl_Booking]
					   ([UserID]
					   ,[BookingStatusID],[CounsellingID]
					   ,[Timestamp])
				  VALUES
					   (@UserID
					   ,4,@CounsellingID
					   ,getdate())
				 SELECT CAST(SCOPE_IDENTITY() as int) as BookingID
	End
else
Begin

		INSERT INTO [dbo].[FormM]
				   ([UserID]
				   ,[AgreementSessRecorded]
				   ,[ACKConfidSessRecorded],CounsellingMasterID)
			 VALUES(@UserID,@AgreementSessRecorded,@ACKConfidSessRecorded,@CounsellingID)

		set @FormID = (SELECT CAST(SCOPE_IDENTITY() as int))
		INSERT INTO [dbo].[FormStatus]
				   ([UserID]
				   ,[FormID]
				   ,[FormType]
				   ,[StepNumber]
				   ,[IsCompleted]
				   ,[Timestamp]
				   ,CounsellingID)
			 VALUES(@UserID,@FormID,'FomrM',2,1,getdate(),@CounsellingID)
			 
		INSERT INTO [dbo].[tbl_Booking]
				   ([UserID]
				   ,[BookingStatusID],[CounsellingID]
				   ,[Timestamp])
			  VALUES
				   (@UserID
				   ,1,@CounsellingID
				   ,getdate())
			 SELECT CAST(SCOPE_IDENTITY() as int) as BookingID
	 End
End
GO
/****** Object:  StoredProcedure [dbo].[PROC_CreateFormN]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CreateFormN]
@ID int null,
@UserID int null,
@CounsellingID int null,
@FullName nvarchar(50)='',
@Status bit = 0,
@PINumber nvarchar(50)='',
@AgreementRuleCoaching bit,
@BookingID int null
AS
Begin

Declare @FormID int =null;
set @FormID = (Select ID from FormN where UserID=@UserID)
if isnull(@FormID,'')<>''
	Begin
	Update [FormN] set [UserID]=@UserID ,AgreementRuleCoaching=@AgreementRuleCoaching where UserID=@UserID
	Update [FormStatus] set [IsCompleted]=1 
		where FormID=@FormID and UserID=@UserID and CounsellingID=@CounsellingID
	SELECT @FormID as ID
	End
Else
	Begin
	INSERT INTO [dbo].[FormN]
			   ([UserID]
			   ,AgreementRuleCoaching)
		 VALUES(@UserID,@AgreementRuleCoaching)

	set @FormID = (SELECT CAST(SCOPE_IDENTITY() as int))
	INSERT INTO [dbo].[FormStatus]
			   ([UserID]
			   ,[FormID]
			   ,[FormType]
			   ,[StepNumber]
			   ,[IsCompleted]
			   ,[Timestamp]
			   ,CounsellingID)
		 VALUES(@UserID,@FormID,'FomrN',2,1,getdate(),@CounsellingID)
		 SELECT CAST(SCOPE_IDENTITY() as int) as ID
	End
End
GO
/****** Object:  StoredProcedure [dbo].[PROC_CreateFormO]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_CreateFormO]
@ID int null,
@UserID int null,
@CounsellingID int null,
@FullName nvarchar(50)='',
@Status bit = 0,
@PINumber nvarchar(50)='',
@AnswertoQuestion varchar(50),
@BookingID int null
AS
Begin
Declare @FormID int =null;
set @FormID = (Select ID from FormO where UserID=@UserID)
if isnull(@FormID,'')<>''
Begin
Update [FormO] set [AnswertoQuestion]=@AnswertoQuestion where UserID=@UserID
Update [FormStatus] set [IsCompleted]=1 
	where FormID=@FormID and UserID=@UserID and CounsellingID=@CounsellingID
	INSERT INTO [dbo].[tbl_Booking]
           ([UserID]
           ,[BookingStatusID],[CounsellingID]
           ,[Timestamp])
      VALUES
           (@UserID
           ,4,@CounsellingID
           ,getdate())	
	SELECT CAST(SCOPE_IDENTITY() as int) as BookingID
End
else
Begin
INSERT INTO [dbo].[FormO]
           ([UserID]
           ,[AnswertoQuestion])
     VALUES(@UserID,@AnswertoQuestion)

set @FormID = (SELECT CAST(SCOPE_IDENTITY() as int))
INSERT INTO [dbo].[FormStatus]
           ([UserID]
           ,[FormID]
           ,[FormType]
           ,[StepNumber]
           ,[IsCompleted]
           ,[Timestamp]
		   ,CounsellingID)
     VALUES(@UserID,@FormID,'FomrO',1,1,getdate(),@CounsellingID)
	INSERT INTO [dbo].[tbl_Booking]
           ([UserID]
           ,[BookingStatusID],[CounsellingID]
           ,[Timestamp])
      VALUES
           (@UserID
           ,1,@CounsellingID
           ,getdate())	
	SELECT CAST(SCOPE_IDENTITY() as int) as BookingID
End
End
GO
/****** Object:  StoredProcedure [dbo].[PROC_GetApproverDetailByBookingID]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_GetApproverDetailByBookingID]
	@BookingID int,
	@Error_Code int = 0 OUTPUT,
	@Error_Message nvarchar(max) = '' OUTPUT
AS
BEGIN
	BEGIN TRY
	Declare @UserID as int
	--Declare @CounsellingType as varchar(50)
	set @UserID = (select UserID from tbl_booking where ID=@BookingID and (BookingStatusID=1 or BookingStatusID=4));
	if isnull(@UserID,'')<>''
	begin

		select [ID] As UserID
		  ,[FullName]
		  ,[Gender]
		  ,[EmailAddress]
		  ,[Password]
		  ,[Status]
		  ,[PINumber]
		  ,[NRICFIN]
		  ,[Race]
		  ,[Ethnicity]
		  ,[Religion]
		  ,[Nationality]
		  ,[MaritalStatus]
		  ,[HighestQualification]
		  ,[EnrolmentYearSem]
		  ,[School]
		  ,[StudyMode]
		  ,[ProgramName]
		  ,[ProgramCode]
		  ,[ProgramStatus]
		  ,[JoinedIntake]
		  ,[MobileNo]
		  ,[MyEmailID]
		  ,[NextKin]	
		from [dbo].[tbl_UsersDetail] where ID = @UserID
		Select * from FormD where UserID=@UserID
		Select * from FormM where UserID=@UserID
		Select * from FormN where UserID=@UserID
		Select * from FormO where UserID=@UserID
		--set @CounsellingType = (Select RouteParams from CounsellingMaster where ID = (select CounsellingID from tbl_booking where ID=@BookingID))
		--if(@CounsellingType='Coaching')
		--		begin
		--		Select * from FormD where UserID=@UserID
		--		Select * from FormN where UserID=@UserID
		--		Select * from FormO where UserID=@UserID
		--		SET @Error_Code = 200 
		--		SET @Error_Message = ''
		--	end
		--else
		--		begin
		--		Select * from FormD where UserID=@UserID
		--		Select * from FormM where UserID=@UserID
		--		SET @Error_Code = 200 
		--		SET @Error_Message = ''
		--		end

		SET @Error_Code = 200 
		SET @Error_Message = ''
	End
	Else
	Begin
	SET @Error_Code = 400 
	SET @Error_Message = 'Not Found'
	End
	END TRY
		BEGIN CATCH
			SET @Error_Code = ERROR_NUMBER()  
			SET @Error_Message = ERROR_MESSAGE()  
			SELECT  'Error #'+ cast(ERROR_NUMBER() as varchar(200))+ ' - '+ERROR_MESSAGE() AS ErrorMessage;   
	END CATCH
END



GO
/****** Object:  StoredProcedure [dbo].[PROC_GetCounsellingMaster]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[PROC_GetCounsellingMaster]
AS
BEGIN
	Select * from CounsellingMaster
END


GO
/****** Object:  StoredProcedure [dbo].[PROC_GetUsersDetailByMyEmailID]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_GetUsersDetailByMyEmailID]
	@MyEmailID varchar(50),
	@Error_Code int = 0 OUTPUT,
	@Error_Message nvarchar(max) = '' OUTPUT
AS
BEGIN
	BEGIN TRY
	
	select [ID] As UserID
      ,[FullName]
      ,[Gender]
      ,[EmailAddress]
      ,[Password]
      ,[Status]
      ,[PINumber]
      ,[NRICFIN]
      ,[Race]
      ,[Ethnicity]
      ,[Religion]
      ,[Nationality]
      ,[MaritalStatus]
      ,[HighestQualification]
      ,[EnrolmentYearSem]
      ,[School]
      ,[StudyMode]
      ,[ProgramName]
      ,[ProgramCode]
      ,[ProgramStatus]
      ,[JoinedIntake]
      ,[MobileNo]
      ,[MyEmailID]
      ,[NextKin]	
	from [dbo].[tbl_UsersDetail] where MyEmailID = @MyEmailID
	SET @Error_Code = 200 
	SET @Error_Message = ''

	END TRY
		BEGIN CATCH
			SET @Error_Code = ERROR_NUMBER()  
			SET @Error_Message = ERROR_MESSAGE()  
			SELECT  'Error #'+ cast(ERROR_NUMBER() as varchar(200))+ ' - '+ERROR_MESSAGE() AS ErrorMessage;   
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_UpdateApproveStatus]    Script Date: 10/1/2024 6:18:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_UpdateApproveStatus]
@ApproverID int null,
@UserID int null,
@CounsellingID int =0,
@StatusID int null
AS
Begin
	if(@StatusID=2)
	begin
	Declare @BookingStatusID int
	set @BookingStatusID= (select BookingStatusID from tbl_booking where Id=@ApproverID and UserID=@UserID);
	if(@BookingStatusID=1)begin  Update tbl_booking set BookingStatusID=@StatusID where Id=@ApproverID and UserID=@UserID end
	else if(@BookingStatusID=4)
	begin
		BEGIN TRANSACTION [ApproverTran]
			BEGIN TRY
					set @CounsellingID= (select CounsellingID from tbl_booking where Id=@ApproverID and UserID=@UserID);
					Update FormStatus set IsCompleted=1 where CounsellingID=@CounsellingID and UserID=@UserID
					Update tbl_booking set BookingStatusID=@StatusID where Id=@ApproverID and UserID=@UserID 
					COMMIT TRANSACTION [ApproverTran]
			END TRY

			BEGIN CATCH
				ROLLBACK TRANSACTION [ApproverTran]		
			END CATCH
	end
	End
	Else if(@StatusID=3)
	begin
		BEGIN TRANSACTION [RejectTran]
			BEGIN TRY	
			  set @CounsellingID = (select CounsellingID from tbl_booking where Id=@ApproverID and UserID=@UserID)
			  Update FormStatus set IsCompleted=0 where CounsellingID=@CounsellingID and UserID=@UserID
			  Update tbl_booking set BookingStatusID=@StatusID where Id=@ApproverID and UserID=@UserID
			  COMMIT TRANSACTION [RejectTran]

			END TRY

			BEGIN CATCH
				ROLLBACK TRANSACTION [RejectTran]		
			END CATCH
	End
End

--Select * from tbl_booking

--Select * from tbl_booking
--Select * from FormStatus
--Select * from FormD
--Select * from FormM
--Select * from FormN
--Select * from FormO
--Select * from CounsellingMaster
--Select * from StatusMaster


--Delete from tbl_booking
--Delete from FormStatus
--Delete from FormD
--Delete from FormM
--Delete from FormN
--Delete from FormO

GO
