using Microsoft.EntityFrameworkCore;
using ECODB1st2024Jul17.Entities;

namespace ECODB1st2024Jul17.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class ECODB1st2024Jul17Context : DbContext
    {
        /// <summary>
        /// Configures the database connection options.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the database connection.</param>
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=192.168.0.5,6969\\\\ECSQLEXPRESS;Initial Catalog=1-ENT_System_Dev;Persist Security Info=True;user id=rahul;password=6cDPaq2Z;Integrated Security=false;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        /// <summary>
        /// Configures the model relationships and entity mappings.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrugSystemTherapeuticClass>().HasKey(a => a.Id);
            modelBuilder.Entity<BatchContext>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasKey(a => a.Id);
            modelBuilder.Entity<IntegrationUser>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<CashRegister>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugListItems>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductCustomUOM>().HasKey(a => a.Id);
            modelBuilder.Entity<Gender>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductTheraputicSubClassification>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeature>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationInstructionTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleType>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientCommunication>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<UnitCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<AddressType>().HasKey(a => a.Id);
            modelBuilder.Entity<PaymentMode>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTransfer>().HasKey(a => a.Id);
            modelBuilder.Entity<CurrencyConversion>().HasKey(a => a.Id);
            modelBuilder.Entity<PrescriptionPrintTemplateComponent>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptSummary>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientTag>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantInvoice>().HasKey(a => a.Id);
            modelBuilder.Entity<ExaminationSection>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugToDiagnosisInteraction>().HasKey(a => a.Id);
            modelBuilder.Entity<JobItem>().HasKey(a => a.Id);
            modelBuilder.Entity<UnitType>().HasKey(a => a.Id);
            modelBuilder.Entity<CurrencyConversionType>().HasKey(a => a.Id);
            modelBuilder.Entity<CoverCategoryClinicTypeExclusion>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrolledPackageSchedulePayment>().HasKey(a => a.Id);
            modelBuilder.Entity<FevouriteRequisitionLine>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>().HasKey(a => a.Id);
            modelBuilder.Entity<OrganizationSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<EntityFieldVisibility>().HasKey(a => a.Id);
            modelBuilder.Entity<CashRegisterVariance>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitGuideline>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<ReadyRxItem>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceList>().HasKey(a => a.Id);
            modelBuilder.Entity<SubReason>().HasKey(a => a.Id);
            modelBuilder.Entity<BatchItemHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitCovid19HistoryParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<IntegrationUserLoginHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnSummary>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitClinicalPrintableNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<JobStatus>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitCovid19History>().HasKey(a => a.Id);
            modelBuilder.Entity<EnrolledProgramDetails>().HasKey(a => a.Id);
            modelBuilder.Entity<CoverCategoryProductCategoryExclusion>().HasKey(a => a.Id);
            modelBuilder.Entity<TaskType>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugToAllergyInteraction>().HasKey(a => a.Id);
            modelBuilder.Entity<PaymentGateway>().HasKey(a => a.Id);
            modelBuilder.Entity<LifeStyleChoice>().HasKey(a => a.Id);
            modelBuilder.Entity<IntegrationUserCredential>().HasKey(a => a.Id);
            modelBuilder.Entity<JobType>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseWorkFlowStep>().HasKey(a => a.Id);
            modelBuilder.Entity<OpeningBalanceItem>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaintVector>().HasKey(a => a.Id);
            modelBuilder.Entity<UserNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<PregnancyHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<CashRegisterHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<ExaminationTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<Medication>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<Smoking>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentSummary>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMedicationDosage>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantReferrals>().HasKey(a => a.Id);
            modelBuilder.Entity<Visit>().HasKey(a => a.Id);
            modelBuilder.Entity<GlobalUser>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitReferralFile>().HasKey(a => a.Id);
            modelBuilder.Entity<CashRegisterReason>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTakeWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListVersion>().HasKey(a => a.Id);
            modelBuilder.Entity<DiagnosisVector>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugToPregnancyInteraction>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTakeItemBatches>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientMedicalHistoryNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisation>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientAccountHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductCategoryRule>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameterValue>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitTask>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentFile>().HasKey(a => a.Id);
            modelBuilder.Entity<AiProcessTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorDrugSystemOrganType>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionFile>().HasKey(a => a.Id);
            modelBuilder.Entity<StockInvoiceSummary>().HasKey(a => a.Id);
            modelBuilder.Entity<Allergy>().HasKey(a => a.Id);
            modelBuilder.Entity<AllergyVector>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitExaminationTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustment>().HasKey(a => a.Id);
            modelBuilder.Entity<SubLocation>().HasKey(a => a.Id);
            modelBuilder.Entity<OrderableComponent>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTakeItem>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugListCountry>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientAllergyParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugInteractionLog>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductSchedule>().HasKey(a => a.Id);
            modelBuilder.Entity<SubscriptionProduct>().HasKey(a => a.Id);
            modelBuilder.Entity<Image>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductGeneric>().HasKey(a => a.Id);
            modelBuilder.Entity<AiFields>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientProcedure>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientPharmacyQueue>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameterRange>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductCategoryGenderRule>().HasKey(a => a.Id);
            modelBuilder.Entity<ComorbidityVector>().HasKey(a => a.Id);
            modelBuilder.Entity<DefaultFormatForLongDate>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitCheckList>().HasKey(a => a.Id);
            modelBuilder.Entity<ImageBinary>().HasKey(a => a.Id);
            modelBuilder.Entity<UserInRole>().HasKey(a => a.Id);
            modelBuilder.Entity<StockSummary>().HasKey(a => a.Id);
            modelBuilder.Entity<Comorbidity>().HasKey(a => a.Id);
            modelBuilder.Entity<Requisition>().HasKey(a => a.Id);
            modelBuilder.Entity<SubscriptionPrice>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameterValueDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<AiInteraction>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugListSpeciality>().HasKey(a => a.Id);
            modelBuilder.Entity<AuthorizationLog>().HasKey(a => a.Id);
            modelBuilder.Entity<ImageSetting>().HasKey(a => a.Id);
            modelBuilder.Entity<GstSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<DefaultFormatForLongTime>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureOrderLine>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationModuleTemplates>().HasKey(a => a.Id);
            modelBuilder.Entity<RoomType>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationVector>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaintTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientProcedureParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductCategoryPatientCategoryRule>().HasKey(a => a.Id);
            modelBuilder.Entity<VideoSession>().HasKey(a => a.Id);
            modelBuilder.Entity<FollowUpReferral>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaintDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitDiagnosisNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationDosage>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSubscriptionAdditionalUser>().HasKey(a => a.Id);
            modelBuilder.Entity<GeneralExamTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrollmentLink>().HasKey(a => a.Id);
            modelBuilder.Entity<DefaultFormatForShortDate>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTakeInitiated>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaint>().HasKey(a => a.Id);
            modelBuilder.Entity<DataImport>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationCountry>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationVector>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeatureParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<TokenManagement>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicType>().HasKey(a => a.Id);
            modelBuilder.Entity<DefaultFormatForShortTime>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductPaymentPlan>().HasKey(a => a.Id);
            modelBuilder.Entity<AiProcess>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<CoverCategoryClinicExclusion>().HasKey(a => a.Id);
            modelBuilder.Entity<GeneralExam>().HasKey(a => a.Id);
            modelBuilder.Entity<FollowupResult>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleEntity>().HasKey(a => a.Id);
            modelBuilder.Entity<AllergyTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturn>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListItem>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTransferSummary>().HasKey(a => a.Id);
            modelBuilder.Entity<DosageForm>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationSpeciality>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorInvestigationProfileItem>().HasKey(a => a.Id);
            modelBuilder.Entity<Location>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrollmentTenantSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<FinanceSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<CoverCategoryProductExclusion>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitTaskResult>().HasKey(a => a.Id);
            modelBuilder.Entity<Language>().HasKey(a => a.Id);
            modelBuilder.Entity<PrescriptionLanguages>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureVector>().HasKey(a => a.Id);
            modelBuilder.Entity<VendorGroup>().HasKey(a => a.Id);
            modelBuilder.Entity<InformationObjects>().HasKey(a => a.Id);
            modelBuilder.Entity<Product>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicalCertificateFile>().HasKey(a => a.Id);
            modelBuilder.Entity<DiagnosisDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTransferFile>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroup>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListComponent>().HasKey(a => a.Id);
            modelBuilder.Entity<ComorbidityTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<AiProviderSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationChiefComplaint>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentItem>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitChiefComplaintNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientLifeStyle>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationDosageFormat>().HasKey(a => a.Id);
            modelBuilder.Entity<ZohoIntegration>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorDiagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicalCertificateOrder>().HasKey(a => a.Id);
            modelBuilder.Entity<ShortFrequencyValueTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<Covid19HistoryChoiceTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationDiagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<PrescriptionFiles>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnItem>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMedicalCertificate>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrolledPackage>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationInstructionTranslationDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<GuideLineDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<MobileVerification>().HasKey(a => a.Id);
            modelBuilder.Entity<SMS>().HasKey(a => a.Id);
            modelBuilder.Entity<Payment>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientPatientCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleOperationScope>().HasKey(a => a.Id);
            modelBuilder.Entity<Lab>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitGeneralExamParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<Email>().HasKey(a => a.Id);
            modelBuilder.Entity<Procedure>().HasKey(a => a.Id);
            modelBuilder.Entity<InformationObjectFields>().HasKey(a => a.Id);
            modelBuilder.Entity<SmsGatewayType>().HasKey(a => a.Id);
            modelBuilder.Entity<LoginHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientAllergy>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationProcedure>().HasKey(a => a.Id);
            modelBuilder.Entity<InvoiceFiles>().HasKey(a => a.Id);
            modelBuilder.Entity<EcCoinRules>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationProfileItem>().HasKey(a => a.Id);
            modelBuilder.Entity<GeneralExamTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<Generic>().HasKey(a => a.Id);
            modelBuilder.Entity<EmailStatus>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptItem>().HasKey(a => a.Id);
            modelBuilder.Entity<DiagnosisTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<CountryCode>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationTemplateVariable>().HasKey(a => a.Id);
            modelBuilder.Entity<ReferredBy>().HasKey(a => a.Id);
            modelBuilder.Entity<EmailTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<State>().HasKey(a => a.Id);
            modelBuilder.Entity<LocationStockBalance>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationInvestigation>().HasKey(a => a.Id);
            modelBuilder.Entity<EcCoinBenefit>().HasKey(a => a.Id);
            modelBuilder.Entity<ChatAssistantSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationOrderLine>().HasKey(a => a.Id);
            modelBuilder.Entity<InformationObjectsRules>().HasKey(a => a.Id);
            modelBuilder.Entity<Entities.File>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorChiefComplaint>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseItem>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientComorbidity>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationModuleEventRelation>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTransferItem>().HasKey(a => a.Id);
            modelBuilder.Entity<Week>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationShortFrequency>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientPayor>().HasKey(a => a.Id);
            modelBuilder.Entity<VitalTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListVersionItem>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductBatch>().HasKey(a => a.Id);
            modelBuilder.Entity<InformationObjectsRuleFields>().HasKey(a => a.Id);
            modelBuilder.Entity<LifeStyleChoiceTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionLine>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationNotesTranslationDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationMedication>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientAllergyParameterValue>().HasKey(a => a.Id);
            modelBuilder.Entity<Report>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationFields>().HasKey(a => a.Id);
            modelBuilder.Entity<OrganisationStockBalance>().HasKey(a => a.Id);
            modelBuilder.Entity<DayVisit>().HasKey(a => a.Id);
            modelBuilder.Entity<EnrolledProgramReward>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitClinicalInternalNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<PackageLine>().HasKey(a => a.Id);
            modelBuilder.Entity<GuidelineTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<ReferredTo>().HasKey(a => a.Id);
            modelBuilder.Entity<OrganizationSettingsFile>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitTypeLocation>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<UserAccessLocation>().HasKey(a => a.Id);
            modelBuilder.Entity<GuidelineTranslationDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<AllergyTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<UomInFormulation>().HasKey(a => a.Id);
            modelBuilder.Entity<DependentInformationObjects>().HasKey(a => a.Id);
            modelBuilder.Entity<Entity>().HasKey(a => a.Id);
            modelBuilder.Entity<AppointmentCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<UserBankDetails>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationExaminationTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugSchedule>().HasKey(a => a.Id);
            modelBuilder.Entity<CredentialHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseItemDosage>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitTypeCheckList>().HasKey(a => a.Id);
            modelBuilder.Entity<UserCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantCulture>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationMeter>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaintSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitInvestigation>().HasKey(a => a.Id);
            modelBuilder.Entity<InformationObjectVersions>().HasKey(a => a.Id);
            modelBuilder.Entity<UOM>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<PatientPregnancy>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationComorbidity>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceipt>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorReport>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<CommunicationTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<Entities.Route>().HasKey(a => a.Id);
            modelBuilder.Entity<UserHoliday>().HasKey(a => a.Id);
            modelBuilder.Entity<InformationObjectFieldSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSubscription>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<AgeUnit>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseFile>().HasKey(a => a.Id);
            modelBuilder.Entity<DiagnosisSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationAllergy>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitVitalParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<SubscriptionCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<FileBinary>().HasKey(a => a.Id);
            modelBuilder.Entity<ReferralOrderLine>().HasKey(a => a.Id);
            modelBuilder.Entity<VitalTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<InventorySettings>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<City>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrder>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<Investigation>().HasKey(a => a.Id);
            modelBuilder.Entity<CoverCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientLifeStyleParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<ExaminationSectionGroup>().HasKey(a => a.Id);
            modelBuilder.Entity<Dispense>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSubscriptionLine>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitInvestigationRecurrence>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTransferCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<sysdiagrams>().HasKey(a => a.diagram_id);
            modelBuilder.Entity<SpecialityPersonalisationComponent>().HasKey(a => a.Id);
            modelBuilder.Entity<FrequencyValue>().HasKey(a => a.Id);
            modelBuilder.Entity<GuidelineSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantInvoicePayment>().HasKey(a => a.Id);
            modelBuilder.Entity<AiMeter>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTakeCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<CommunicationModuleEventTemplateRelation>().HasKey(a => a.Id);
            modelBuilder.Entity<ContactMember>().HasKey(a => a.Id);
            modelBuilder.Entity<FileSetting>().HasKey(a => a.Id);
            modelBuilder.Entity<GuidelineGroupItem>().HasKey(a => a.Id);
            modelBuilder.Entity<ReportDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<InvoiceTaxBreakup>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTake>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationVerification>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaintTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorComorbidity>().HasKey(a => a.Id);
            modelBuilder.Entity<TemplateComponentParameters>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductRule>().HasKey(a => a.Id);
            modelBuilder.Entity<ProducedType>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<EntityVectorConfiguration>().HasKey(a => a.Id);
            modelBuilder.Entity<ExaminationSectionGroupParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<SpecialityPersonalisationDruglist>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationInstruction>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureOrder>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationOrderCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<ReferralOrderCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<IntegrationUserToken>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorInvestigation>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationOrder>().HasKey(a => a.Id);
            modelBuilder.Entity<ReportAccess>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorAllergy>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationEventTemplates>().HasKey(a => a.Id);
            modelBuilder.Entity<Formulation>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitInvestigationNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<ExaminationTemplateSection>().HasKey(a => a.Id);
            modelBuilder.Entity<EntityOperation>().HasKey(a => a.Id);
            modelBuilder.Entity<WorkFlow>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicalCertificateOrderCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<Guideline>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationContextType>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorProcedure>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductGenderRule>().HasKey(a => a.Id);
            modelBuilder.Entity<PrescriptionFooter>().HasKey(a => a.Id);
            modelBuilder.Entity<Membership>().HasKey(a => a.Id);
            modelBuilder.Entity<EMRSuggestionLog>().HasKey(a => a.Id);
            modelBuilder.Entity<UserGoogleAuthorization>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureOrderCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<ThirdPartyIntegration>().HasKey(a => a.Id);
            modelBuilder.Entity<EmrTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<Package>().HasKey(a => a.Id);
            modelBuilder.Entity<Speciality>().HasKey(a => a.Id);
            modelBuilder.Entity<Tenant>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantDeleteOtp>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductUom>().HasKey(a => a.Id);
            modelBuilder.Entity<InvoiceCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<CommunicationLog>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasKey(a => a.Id);
            modelBuilder.Entity<AccountSettlement>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitChiefComplaint>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitWorkFlowStep>().HasKey(a => a.Id);
            modelBuilder.Entity<Contact>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationMode>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductPackage>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductPatientCategoryRule>().HasKey(a => a.Id);
            modelBuilder.Entity<CreditInvoiceCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<IcdCode>().HasKey(a => a.Id);
            modelBuilder.Entity<FrequencyValueTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<Qualification>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitGeneralExam>().HasKey(a => a.Id);
            modelBuilder.Entity<WorkFlowStates>().HasKey(a => a.Id);
            modelBuilder.Entity<AllergyDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<TemplateComponents>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitDiagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderFile>().HasKey(a => a.Id);
            modelBuilder.Entity<PaymentCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<MedicationComposition>().HasKey(a => a.Id);
            modelBuilder.Entity<DespenceCounter>().HasKey(a => a.TenantId);
            modelBuilder.Entity<CoverCategorySubscription>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductLocationPrice>().HasKey(a => a.Id);
            modelBuilder.Entity<Lifestyle>().HasKey(a => a.Id);
            modelBuilder.Entity<ContactProductCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<Invoice>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTakeFile>().HasKey(a => a.Id);
            modelBuilder.Entity<DiagnosisTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<PackageLineSubGroup>().HasKey(a => a.Id);
            modelBuilder.Entity<NationalIdType>().HasKey(a => a.Id);
            modelBuilder.Entity<FavouritePurchaseOrderLine>().HasKey(a => a.Id);
            modelBuilder.Entity<Settings>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptFile>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrolledPackageSchedule>().HasKey(a => a.Id);
            modelBuilder.Entity<OtherMedicationTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<EntityFieldAuthorization>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductManufacture>().HasKey(a => a.Id);
            modelBuilder.Entity<ComorbidityTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<WorkFlowTransitions>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantExtension>().HasKey(a => a.Id);
            modelBuilder.Entity<UserDrugList>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMedicationRefill>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitInvestigationResult>().HasKey(a => a.Id);
            modelBuilder.Entity<ContactInformation>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantAuthorizationFunctions>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnFile>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<AppointmentReminderLog>().HasKey(a => a.Id);
            modelBuilder.Entity<ReferralOrder>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<UomValueTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<WorkFlowConfiguration>().HasKey(a => a.Id);
            modelBuilder.Entity<Covid19History>().HasKey(a => a.Id);
            modelBuilder.Entity<Diagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrolledPackageProducts>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientStatistics>().HasKey(a => a.Id);
            modelBuilder.Entity<VoidReason>().HasKey(a => a.Id);
            modelBuilder.Entity<NotesShortcut>().HasKey(a => a.Id);
            modelBuilder.Entity<InputType>().HasKey(a => a.Id);
            modelBuilder.Entity<OrganizationBankDetail>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductFormulation>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaintVector_Test>().HasKey(a => a.Id);
            modelBuilder.Entity<LoyaltyProgram>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitReferral>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitInvestigationResultParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<NotesShortcutDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<FavouriteGoodsReceiptLine>().HasKey(a => a.Id);
            modelBuilder.Entity<BatchTypeContext>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleOperation>().HasKey(a => a.Id);
            modelBuilder.Entity<Covid19HistoryChoiceTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<DataType>().HasKey(a => a.Id);
            modelBuilder.Entity<LoyaltyProgramRule>().HasKey(a => a.Id);
            modelBuilder.Entity<SmsLog>().HasKey(a => a.Id);
            modelBuilder.Entity<Active>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugList>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductClassification>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationNotesTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<WorkFlowConfigurationTransition>().HasKey(a => a.Id);
            modelBuilder.Entity<ComorbidityDeviation>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductPackageItems>().HasKey(a => a.Id);
            modelBuilder.Entity<TagsMaster>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitExaminationTemplateSection>().HasKey(a => a.Id);
            modelBuilder.Entity<PackageLineSubGroupFeature>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMode>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitVoiceTranscript>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantInvoiceLine>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptSuggestion>().HasKey(a => a.Id);
            modelBuilder.Entity<Counter>().HasKey(a => a.Id);
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<BatchInterval>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<LifeStyleChoiceTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<OpeningBalance>().HasKey(a => a.Id);
            modelBuilder.Entity<Covid19HistoryChoice>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitExaminationTemplateSectionColumn>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitReferralNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<PackageLineSubGroupFeatureParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugSystemOrganType>().HasKey(a => a.Id);
            modelBuilder.Entity<UserCredentialLogin>().HasKey(a => a.Id);
            modelBuilder.Entity<Entities.AppointmentService>().HasKey(a => a.Id);
            modelBuilder.Entity<Occupation>().HasKey(a => a.Id);
            modelBuilder.Entity<CalenderSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<InvestigationRecordResult>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantInvoiceFiles>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientComorbidityParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<Country>().HasKey(a => a.Id);
            modelBuilder.Entity<WorkFlowConfigurationTransitionAuthorization>().HasKey(a => a.Id);
            modelBuilder.Entity<EmrGeneralSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<EnrolledProgram>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListVersionComponent>().HasKey(a => a.Id);
            modelBuilder.Entity<InvoiceLine>().HasKey(a => a.Id);
            modelBuilder.Entity<Credential>().HasKey(a => a.Id);
            modelBuilder.Entity<UserRoster>().HasKey(a => a.Id);
            modelBuilder.Entity<StockTransferWorkflowActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<UOMConversion>().HasKey(a => a.Id);
            modelBuilder.Entity<Timezone>().HasKey(a => a.Id);
            modelBuilder.Entity<Currency>().HasKey(a => a.Id);
            modelBuilder.Entity<CommunicationProviderSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductTheraputicClassification>().HasKey(a => a.Id);
            modelBuilder.Entity<TenantSubscriptionLineSubGroup>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitType>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderLine>().HasKey(a => a.Id);
            modelBuilder.Entity<Title>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugToDrugInteraction>().HasKey(a => a.Id);
            modelBuilder.Entity<PrescriptionPrintTemplate>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroupParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<Notification>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMedication>().HasKey(a => a.Id);
            modelBuilder.Entity<PackageSubscription>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugSystemTherapeuticClass>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugSystemTherapeuticClass>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugSystemTherapeuticClass>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugSystemTherapeuticClass>().HasOne(a => a.DrugSystemOrganType_DrugSystemOrganType).WithMany().HasForeignKey(c => c.DrugSystemOrganType);
            modelBuilder.Entity<BatchContext>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<BatchContext>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<BatchContext>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasOne(a => a.DrugSystemTherapeuticClass_DrugSystemTherapeuticClass).WithMany().HasForeignKey(c => c.DrugSystemTherapeuticClass);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DoctorDrugSystemTherapeuticClass>().HasOne(a => a.DrugSystemOrganType_DrugSystemOrganType).WithMany().HasForeignKey(c => c.DrugSystemOrganType);
            modelBuilder.Entity<IntegrationUser>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<IntegrationUser>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<IntegrationUser>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasOne(a => a.ProcedureOrderId_ProcedureOrder).WithMany().HasForeignKey(c => c.ProcedureOrderId);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasOne(a => a.ProcedureOrderLineId_ProcedureOrderLine).WithMany().HasForeignKey(c => c.ProcedureOrderLineId);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProcedureOrderWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<CashRegister>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CashRegister>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<CashRegister>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CashRegister>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CashRegister>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<DrugListItems>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugListItems>().HasOne(a => a.DrugListId_DrugList).WithMany().HasForeignKey(c => c.DrugListId);
            modelBuilder.Entity<ProductCustomUOM>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Gender>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Gender>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Gender>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductTheraputicSubClassification>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductTheraputicSubClassification>().HasOne(a => a.ProductTheraputicClassificationId_ProductTheraputicClassification).WithMany().HasForeignKey(c => c.ProductTheraputicClassificationId);
            modelBuilder.Entity<ProductTheraputicSubClassification>().HasOne(a => a.DrugSystemOrganTypeId_DrugSystemOrganType).WithMany().HasForeignKey(c => c.DrugSystemOrganTypeId);
            modelBuilder.Entity<ProductTheraputicSubClassification>().HasOne(a => a.DrugSystemTherapeuticClassId_DrugSystemTherapeuticClass).WithMany().HasForeignKey(c => c.DrugSystemTherapeuticClassId);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeature>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeature>().HasOne(a => a.TenantSubscriptionLineSubGroup_TenantSubscriptionLineSubGroup).WithMany().HasForeignKey(c => c.TenantSubscriptionLineSubGroup);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeature>().HasOne(a => a.PackageLineSubGroupFeature_PackageLineSubGroupFeature).WithMany().HasForeignKey(c => c.PackageLineSubGroupFeature);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeature>().HasOne(a => a.FeatureParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.FeatureParameterId);
            modelBuilder.Entity<MedicationInstructionTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationInstructionTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<MedicationInstructionTranslation>().HasOne(a => a.InstructionId_MedicationInstruction).WithMany().HasForeignKey(c => c.InstructionId);
            modelBuilder.Entity<MedicationInstructionTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationInstructionTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RoleType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RoleType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientCommunication>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientCommunication>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<RequisitionSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RequisitionSuggestion>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<RequisitionSuggestion>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<VisitActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitActivityHistory>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitActivityHistory>().HasOne(a => a.TransactionBy_User).WithMany().HasForeignKey(c => c.TransactionBy);
            modelBuilder.Entity<VisitActivityHistory>().HasOne(a => a.AssignedUser_User).WithMany().HasForeignKey(c => c.AssignedUser);
            modelBuilder.Entity<GoodsReceiptWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceiptWorkflowActivityHistory>().HasOne(a => a.GoodsReceiptId_GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<GoodsReceiptWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GoodsReceiptWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UnitCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UnitCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UnitCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AddressType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AddressType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AddressType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PaymentMode>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PaymentMode>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PaymentMode>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTransfer>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTransfer>().HasOne(a => a.LocationFromId_Location).WithMany().HasForeignKey(c => c.LocationFromId);
            modelBuilder.Entity<StockTransfer>().HasOne(a => a.LocationToId_Location).WithMany().HasForeignKey(c => c.LocationToId);
            modelBuilder.Entity<StockTransfer>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockTransfer>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTransfer>().HasOne(a => a.SubLocationToId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationToId);
            modelBuilder.Entity<CurrencyConversion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CurrencyConversion>().HasOne(a => a.FromCurrencyId_Currency).WithMany().HasForeignKey(c => c.FromCurrencyId);
            modelBuilder.Entity<CurrencyConversion>().HasOne(a => a.ToCurrencyId_Currency).WithMany().HasForeignKey(c => c.ToCurrencyId);
            modelBuilder.Entity<CurrencyConversion>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CurrencyConversion>().HasOne(a => a.ConversionTypeId_CurrencyConversionType).WithMany().HasForeignKey(c => c.ConversionTypeId);
            modelBuilder.Entity<CurrencyConversion>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PrescriptionPrintTemplateComponent>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PrescriptionPrintTemplateComponent>().HasOne(a => a.PrescriptionPrintTemplateId_PrescriptionPrintTemplate).WithMany().HasForeignKey(c => c.PrescriptionPrintTemplateId);
            modelBuilder.Entity<GoodsReceiptSummary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceiptSummary>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<GoodsReceiptSummary>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<GoodsReceiptSummary>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PatientTag>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientTag>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientTag>().HasOne(a => a.TagsMasterId_TagsMaster).WithMany().HasForeignKey(c => c.TagsMasterId);
            modelBuilder.Entity<PatientTag>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientTag>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<TenantInvoice>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantInvoice>().HasOne(a => a.TenantSubscriptionId_TenantSubscription).WithMany().HasForeignKey(c => c.TenantSubscriptionId);
            modelBuilder.Entity<ExaminationSection>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ExaminationSection>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ExaminationSection>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugToDiagnosisInteraction>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugToDiagnosisInteraction>().HasOne(a => a.ToDiagnosis_Diagnosis).WithMany().HasForeignKey(c => c.ToDiagnosis);
            modelBuilder.Entity<DrugToDiagnosisInteraction>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugToDiagnosisInteraction>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<JobItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<JobItem>().HasOne(a => a.BatchTypeId_JobType).WithMany().HasForeignKey(c => c.BatchTypeId);
            modelBuilder.Entity<JobItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<JobItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UnitType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UnitType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UnitType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CurrencyConversionType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CurrencyConversionType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CurrencyConversionType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CoverCategoryClinicTypeExclusion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CoverCategoryClinicTypeExclusion>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<CoverCategoryClinicTypeExclusion>().HasOne(a => a.ClinicTypeId_ClinicType).WithMany().HasForeignKey(c => c.ClinicTypeId);
            modelBuilder.Entity<PatientEnrolledPackageSchedulePayment>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientEnrolledPackageSchedulePayment>().HasOne(a => a.PatientEnrolledPackageId_PatientEnrolledPackage).WithMany().HasForeignKey(c => c.PatientEnrolledPackageId);
            modelBuilder.Entity<PatientEnrolledPackageSchedulePayment>().HasOne(a => a.PaymentId_Payment).WithMany().HasForeignKey(c => c.PaymentId);
            modelBuilder.Entity<PatientEnrolledPackageSchedulePayment>().HasOne(a => a.PatientEnrolledPackageScheduleId_PatientEnrolledPackageSchedule).WithMany().HasForeignKey(c => c.PatientEnrolledPackageScheduleId);
            modelBuilder.Entity<FevouriteRequisitionLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FevouriteRequisitionLine>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<FevouriteRequisitionLine>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Patient>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Patient>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Patient>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Patient>().HasOne(a => a.ReferredById_Contact).WithMany().HasForeignKey(c => c.ReferredById);
            modelBuilder.Entity<Patient>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Patient>().HasOne(a => a.MembershipId_Membership).WithMany().HasForeignKey(c => c.MembershipId);
            modelBuilder.Entity<Patient>().HasOne(a => a.Title_Title).WithMany().HasForeignKey(c => c.Title);
            modelBuilder.Entity<OrganizationSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OrganizationSettings>().HasOne(a => a.StateId_State).WithMany().HasForeignKey(c => c.StateId);
            modelBuilder.Entity<OrganizationSettings>().HasOne(a => a.CityId_City).WithMany().HasForeignKey(c => c.CityId);
            modelBuilder.Entity<OrganizationSettings>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<OrganizationSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<OrganizationSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<EntityFieldVisibility>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CashRegisterVariance>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CashRegisterVariance>().HasOne(a => a.CashRegisterId_CashRegister).WithMany().HasForeignKey(c => c.CashRegisterId);
            modelBuilder.Entity<CashRegisterVariance>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<CashRegisterVariance>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CashRegisterVariance>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<VisitGuideline>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitGuideline>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitGuideline>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitGuideline>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DispenseActivityHistory>().HasOne(a => a.DispenseId_Dispense).WithMany().HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<DispenseActivityHistory>().HasOne(a => a.TransactionBy_User).WithMany().HasForeignKey(c => c.TransactionBy);
            modelBuilder.Entity<DispenseActivityHistory>().HasOne(a => a.AssignedUser_User).WithMany().HasForeignKey(c => c.AssignedUser);
            modelBuilder.Entity<ReadyRxItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReadyRxItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ReadyRxItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ReadyRxItem>().HasOne(a => a.ReadyRx_Medication).WithMany().HasForeignKey(c => c.ReadyRx);
            modelBuilder.Entity<ReadyRxItem>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<PriceList>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PriceList>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PriceList>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SubReason>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SubReason>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<SubReason>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<BatchItemHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitCovid19HistoryParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitCovid19HistoryParameter>().HasOne(a => a.VisitCovid19History_VisitCovid19History).WithMany().HasForeignKey(c => c.VisitCovid19History);
            modelBuilder.Entity<VisitCovid19HistoryParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitCovid19HistoryParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<IntegrationUserLoginHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<IntegrationUserLoginHistory>().HasOne(a => a.IntegrationUserId_IntegrationUser).WithMany().HasForeignKey(c => c.IntegrationUserId);
            modelBuilder.Entity<GoodsReturnSummary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReturnSummary>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<GoodsReturnSummary>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<GoodsReturnSummary>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<GoodsReturnWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReturnWorkflowActivityHistory>().HasOne(a => a.GoodsReturnId_GoodsReturn).WithMany().HasForeignKey(c => c.GoodsReturnId);
            modelBuilder.Entity<GoodsReturnWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<GoodsReturnWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GoodsReturnWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<VisitClinicalPrintableNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitClinicalPrintableNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitClinicalPrintableNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitClinicalPrintableNotes>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<Appointment>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Appointment>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Visitid_Visit).WithMany().HasForeignKey(c => c.Visitid);
            modelBuilder.Entity<Appointment>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Appointment>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<JobStatus>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<JobStatus>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<JobStatus>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitCovid19History>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitCovid19History>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitCovid19History>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<VisitCovid19History>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitCovid19History>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<EnrolledProgramDetails>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EnrolledProgramDetails>().HasOne(a => a.EnrolledProgramId_EnrolledProgram).WithMany().HasForeignKey(c => c.EnrolledProgramId);
            modelBuilder.Entity<CoverCategoryProductCategoryExclusion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CoverCategoryProductCategoryExclusion>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<CoverCategoryProductCategoryExclusion>().HasOne(a => a.ProductCategoryId_ProductCategory).WithMany().HasForeignKey(c => c.ProductCategoryId);
            modelBuilder.Entity<TaskType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TaskType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<TaskType>().HasOne(a => a.DurationUom_UOM).WithMany().HasForeignKey(c => c.DurationUom);
            modelBuilder.Entity<TaskType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugToAllergyInteraction>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugToAllergyInteraction>().HasOne(a => a.ToAllergy_Allergy).WithMany().HasForeignKey(c => c.ToAllergy);
            modelBuilder.Entity<DrugToAllergyInteraction>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugToAllergyInteraction>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<LifeStyleChoice>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<LifeStyleChoice>().HasOne(a => a.Lifestyle_Lifestyle).WithMany().HasForeignKey(c => c.Lifestyle);
            modelBuilder.Entity<LifeStyleChoice>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<LifeStyleChoice>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<IntegrationUserCredential>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<IntegrationUserCredential>().HasOne(a => a.IntegrationUserId_IntegrationUser).WithMany().HasForeignKey(c => c.IntegrationUserId);
            modelBuilder.Entity<IntegrationUserCredential>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<IntegrationUserCredential>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<JobType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<JobType>().HasOne(a => a.Context_BatchTypeContext).WithMany().HasForeignKey(c => c.Context);
            modelBuilder.Entity<JobType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<JobType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseWorkFlowStep>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OpeningBalanceItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OpeningBalanceItem>().HasOne(a => a.OpeningBalanceId_OpeningBalance).WithMany().HasForeignKey(c => c.OpeningBalanceId);
            modelBuilder.Entity<OpeningBalanceItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<OpeningBalanceItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<OpeningBalanceItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ChiefComplaintVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintVector>().HasOne(a => a.ChiefComplaintId_ChiefComplaint).WithMany().HasForeignKey(c => c.ChiefComplaintId);
            modelBuilder.Entity<UserNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserNotes>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PregnancyHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PregnancyHistory>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PregnancyHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CashRegisterHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CashRegisterHistory>().HasOne(a => a.CashRegisterId_CashRegister).WithMany().HasForeignKey(c => c.CashRegisterId);
            modelBuilder.Entity<CashRegisterHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CashRegisterHistory>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<CashRegisterHistory>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<CashRegisterHistory>().HasOne(a => a.CashRegisterReasonId_CashRegisterReason).WithMany().HasForeignKey(c => c.CashRegisterReasonId);
            modelBuilder.Entity<ExaminationTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ExaminationTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ExaminationTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ExaminationTemplate>().HasOne(a => a.SpecialityId_Speciality).WithMany().HasForeignKey(c => c.SpecialityId);
            modelBuilder.Entity<Medication>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Medication>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Medication>().HasOne(a => a.RouteId_Route).WithMany().HasForeignKey(c => c.RouteId);
            modelBuilder.Entity<Medication>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Medication>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<Smoking>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Smoking>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Smoking>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockAdjustmentSummary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockAdjustmentSummary>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockAdjustmentSummary>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<StockAdjustmentSummary>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<VisitMedicationDosage>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitMedicationDosage>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitMedicationDosage>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitMedicationDosage>().HasOne(a => a.VisitMedication_VisitMedication).WithMany().HasForeignKey(c => c.VisitMedication);
            modelBuilder.Entity<VisitMedicationDosage>().HasOne(a => a.DosageForm_UomInFormulation).WithMany().HasForeignKey(c => c.DosageForm);
            modelBuilder.Entity<TenantReferrals>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantReferrals>().HasOne(a => a.ReferredTenantId_Tenant).WithMany().HasForeignKey(c => c.ReferredTenantId);
            modelBuilder.Entity<TenantReferrals>().HasOne(a => a.EnrolledProgramId_EnrolledProgram).WithMany().HasForeignKey(c => c.EnrolledProgramId);
            modelBuilder.Entity<TenantReferrals>().HasOne(a => a.EnrolledProgramDetailsId_EnrolledProgramDetails).WithMany().HasForeignKey(c => c.EnrolledProgramDetailsId);
            modelBuilder.Entity<Visit>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitType_VisitType).WithMany().HasForeignKey(c => c.VisitType);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitMode_VisitMode).WithMany().HasForeignKey(c => c.VisitMode);
            modelBuilder.Entity<Visit>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Visit>().HasOne(a => a.SubscriptionId_SubscriptionCategory).WithMany().HasForeignKey(c => c.SubscriptionId);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitTemplateId_EmrTemplate).WithMany().HasForeignKey(c => c.VisitTemplateId);
            modelBuilder.Entity<Visit>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Visit>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<Visit>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<Visit>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GlobalUser>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GlobalUser>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GlobalUser>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitReferralFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitReferralFile>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitReferralFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CashRegisterReason>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTakeWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTakeWorkflowActivityHistory>().HasOne(a => a.StockTakeId_StockTake).WithMany().HasForeignKey(c => c.StockTakeId);
            modelBuilder.Entity<StockTakeWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<StockTakeWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockTakeWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasOne(a => a.ClinicalParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasOne(a => a.ReplacedClinicalParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.ReplacedClinicalParameterId);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ClinicalParameterDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<TenantSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<TenantSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PriceListVersion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PriceListVersion>().HasOne(a => a.PriceListId_PriceList).WithMany().HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListVersion>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DiagnosisVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DiagnosisVector>().HasOne(a => a.DiagnosisId_Diagnosis).WithMany().HasForeignKey(c => c.DiagnosisId);
            modelBuilder.Entity<DrugToPregnancyInteraction>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugToPregnancyInteraction>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugToPregnancyInteraction>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTakeItemBatches>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTakeItemBatches>().HasOne(a => a.StockTakeItemId_StockTakeItem).WithMany().HasForeignKey(c => c.StockTakeItemId);
            modelBuilder.Entity<StockTakeItemBatches>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<ProcedureTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProcedureTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientMedicalHistoryNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientMedicalHistoryNotes>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientMedicalHistoryNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientMedicalHistoryNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientMedicalHistoryNotes>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<SpecialityPersonalisation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<SpecialityPersonalisation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientAccountHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientAccountHistory>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientAccountHistory>().HasOne(a => a.PaymentMode_PaymentMode).WithMany().HasForeignKey(c => c.PaymentMode);
            modelBuilder.Entity<PatientAccountHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientAccountHistory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientAccountHistory>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<ProductCategoryRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductCategoryRule>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<ProductCategoryRule>().HasOne(a => a.ProductCategoryId_ProductCategory).WithMany().HasForeignKey(c => c.ProductCategoryId);
            modelBuilder.Entity<ProductCategoryRule>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductCategoryRule>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ClinicalParameterValue>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ClinicalParameterValue>().HasOne(a => a.Id_ClinicalParameterValue).WithMany().HasForeignKey(c => c.Id);
            modelBuilder.Entity<ClinicalParameterValue>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<ClinicalParameterValue>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ClinicalParameterValue>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.TaskId_TaskType).WithMany().HasForeignKey(c => c.TaskId);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.AssignTo_User).WithMany().HasForeignKey(c => c.AssignTo);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<VisitTask>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockAdjustmentFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockAdjustmentFile>().HasOne(a => a.StockAdjustmentId_StockAdjustment).WithMany().HasForeignKey(c => c.StockAdjustmentId);
            modelBuilder.Entity<StockAdjustmentFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AiProcessTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AiProcessTemplate>().HasOne(a => a.AiProcessId_AiProcess).WithMany().HasForeignKey(c => c.AiProcessId);
            modelBuilder.Entity<AiProcessTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AiProcessTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DoctorDrugSystemOrganType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorDrugSystemOrganType>().HasOne(a => a.DrugSystemOrganType_DrugSystemOrganType).WithMany().HasForeignKey(c => c.DrugSystemOrganType);
            modelBuilder.Entity<DoctorDrugSystemOrganType>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorDrugSystemOrganType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorDrugSystemOrganType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RequisitionFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RequisitionFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockInvoiceSummary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockInvoiceSummary>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockInvoiceSummary>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<StockInvoiceSummary>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Allergy>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Allergy>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Allergy>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Allergy>().HasOne(a => a.AllergyTemplate_AllergyTemplate).WithMany().HasForeignKey(c => c.AllergyTemplate);
            modelBuilder.Entity<AllergyVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AllergyVector>().HasOne(a => a.AllergyId_Allergy).WithMany().HasForeignKey(c => c.AllergyId);
            modelBuilder.Entity<VisitExaminationTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitExaminationTemplate>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitExaminationTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitExaminationTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SubLocation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SubLocation>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<SubLocation>().HasOne(a => a.RoomTypeId_RoomType).WithMany().HasForeignKey(c => c.RoomTypeId);
            modelBuilder.Entity<SubLocation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<SubLocation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<OrderableComponent>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OrderableComponent>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<OrderableComponent>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTakeItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTakeItem>().HasOne(a => a.StockTakeId_StockTake).WithMany().HasForeignKey(c => c.StockTakeId);
            modelBuilder.Entity<StockTakeItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockTakeItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockTakeItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugListCountry>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugListCountry>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<DrugListCountry>().HasOne(a => a.DrugListId_DrugList).WithMany().HasForeignKey(c => c.DrugListId);
            modelBuilder.Entity<PatientAllergyParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientAllergyParameter>().HasOne(a => a.PatientAllergy_PatientAllergy).WithMany().HasForeignKey(c => c.PatientAllergy);
            modelBuilder.Entity<PatientAllergyParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientAllergyParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugInteractionLog>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugInteractionLog>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<DrugInteractionLog>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<DrugInteractionLog>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductSchedule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductSchedule>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductSchedule>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductSchedule>().HasOne(a => a.ReferenceProductScheduleId_ProductSchedule).WithMany().HasForeignKey(c => c.ReferenceProductScheduleId);
            modelBuilder.Entity<ProductSchedule>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductSchedule>().HasOne(a => a.DurationUomId_UOM).WithMany().HasForeignKey(c => c.DurationUomId);
            modelBuilder.Entity<Image>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Image>().HasOne(a => a.BinaryImageId_ImageBinary).WithMany().HasForeignKey(c => c.BinaryImageId);
            modelBuilder.Entity<Image>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Image>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductGeneric>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductGeneric>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductGeneric>().HasOne(a => a.GenericId_Generic).WithMany().HasForeignKey(c => c.GenericId);
            modelBuilder.Entity<ProductGeneric>().HasOne(a => a.UOM_UOM).WithMany().HasForeignKey(c => c.UOM);
            modelBuilder.Entity<ProductGeneric>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductGeneric>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AiFields>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationTemplate>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<PatientProcedure>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientProcedure>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientProcedure>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientProcedure>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientProcedure>().HasOne(a => a.InvoiceLineId_InvoiceLine).WithMany().HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<PatientProcedure>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.DispenseId_Dispense).WithMany().HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.AssignToUser_User).WithMany().HasForeignKey(c => c.AssignToUser);
            modelBuilder.Entity<ClinicalParameterRange>().HasOne(a => a.Id_ClinicalParameterRange).WithMany().HasForeignKey(c => c.Id);
            modelBuilder.Entity<ClinicalParameterRange>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ClinicalParameterRange>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<ClinicalParameterRange>().HasOne(a => a.GenderId_Gender).WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<ProductCategoryGenderRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductCategoryGenderRule>().HasOne(a => a.ProductCategoryRuleId_ProductCategoryRule).WithMany().HasForeignKey(c => c.ProductCategoryRuleId);
            modelBuilder.Entity<ProductCategoryGenderRule>().HasOne(a => a.GenderId_Gender).WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<ComorbidityVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ComorbidityVector>().HasOne(a => a.ComorbidityId_Comorbidity).WithMany().HasForeignKey(c => c.ComorbidityId);
            modelBuilder.Entity<DefaultFormatForLongDate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DefaultFormatForLongDate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DefaultFormatForLongDate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitCheckList>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitCheckList>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitCheckList>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ImageBinary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.Role_Role).WithMany().HasForeignKey(c => c.Role);
            modelBuilder.Entity<StockSummary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockSummary>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockSummary>().HasOne(a => a.UomId_UOM).WithMany().HasForeignKey(c => c.UomId);
            modelBuilder.Entity<StockSummary>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<StockSummary>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Comorbidity>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Comorbidity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Comorbidity>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Comorbidity>().HasOne(a => a.ComorbidityTemplate_ComorbidityTemplate).WithMany().HasForeignKey(c => c.ComorbidityTemplate);
            modelBuilder.Entity<Requisition>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Requisition>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Requisition>().HasOne(a => a.RequestBy_User).WithMany().HasForeignKey(c => c.RequestBy);
            modelBuilder.Entity<Requisition>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Requisition>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SubscriptionPrice>().HasOne(a => a.SubscriptionProductId_SubscriptionProduct).WithMany().HasForeignKey(c => c.SubscriptionProductId);
            modelBuilder.Entity<SubscriptionPrice>().HasOne(a => a.PackageId_Package).WithMany().HasForeignKey(c => c.PackageId);
            modelBuilder.Entity<ClinicalParameterValueDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ClinicalParameterValueDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ClinicalParameterValueDeviation>().HasOne(a => a.ReplacedClinicalParameterValueId_ClinicalParameterValue).WithMany().HasForeignKey(c => c.ReplacedClinicalParameterValueId);
            modelBuilder.Entity<ClinicalParameterValueDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ClinicalParameterValueDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<AiInteraction>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AiInteraction>().HasOne(a => a.AiProcessId_AiProcess).WithMany().HasForeignKey(c => c.AiProcessId);
            modelBuilder.Entity<AiInteraction>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugListSpeciality>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugListSpeciality>().HasOne(a => a.SpecialityId_Speciality).WithMany().HasForeignKey(c => c.SpecialityId);
            modelBuilder.Entity<DrugListSpeciality>().HasOne(a => a.DrugListId_DrugList).WithMany().HasForeignKey(c => c.DrugListId);
            modelBuilder.Entity<AuthorizationLog>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AuthorizationLog>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<AuthorizationLog>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<AuthorizationLog>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<AuthorizationLog>().HasOne(a => a.ContactMemberId_ContactMember).WithMany().HasForeignKey(c => c.ContactMemberId);
            modelBuilder.Entity<ImageSetting>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ImageSetting>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ImageSetting>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GstSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GstSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GstSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DefaultFormatForLongTime>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DefaultFormatForLongTime>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DefaultFormatForLongTime>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.ProcedureOrderId_ProcedureOrder).WithMany().HasForeignKey(c => c.ProcedureOrderId);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.PatientProcedureId_PatientProcedure).WithMany().HasForeignKey(c => c.PatientProcedureId);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.ProcedureId_Procedure).WithMany().HasForeignKey(c => c.ProcedureId);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureOrderLine>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<CommunicationModuleTemplates>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationModuleTemplates>().HasOne(a => a.CommunicationModuleId_CommunicationModuleEventRelation).WithMany().HasForeignKey(c => c.CommunicationModuleId);
            modelBuilder.Entity<CommunicationModuleTemplates>().HasOne(a => a.CommunicationTemplateId_CommunicationTemplate).WithMany().HasForeignKey(c => c.CommunicationTemplateId);
            modelBuilder.Entity<RoomType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoomType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RoomType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationVector>().HasOne(a => a.InvestigationId_Investigation).WithMany().HasForeignKey(c => c.InvestigationId);
            modelBuilder.Entity<ChiefComplaintTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ChiefComplaintTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientProcedureParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientProcedureParameter>().HasOne(a => a.PatientProcedure_PatientProcedure).WithMany().HasForeignKey(c => c.PatientProcedure);
            modelBuilder.Entity<PatientProcedureParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientProcedureParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductCategoryPatientCategoryRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductCategoryPatientCategoryRule>().HasOne(a => a.ProductCategoryRuleId_ProductCategoryRule).WithMany().HasForeignKey(c => c.ProductCategoryRuleId);
            modelBuilder.Entity<ProductCategoryPatientCategoryRule>().HasOne(a => a.PatientCategoryId_PatientCategory).WithMany().HasForeignKey(c => c.PatientCategoryId);
            modelBuilder.Entity<VideoSession>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VideoSession>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<VideoSession>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<VideoSession>().HasOne(a => a.ClosedByPatient_Patient).WithMany().HasForeignKey(c => c.ClosedByPatient);
            modelBuilder.Entity<VideoSession>().HasOne(a => a.ClosedByUser_User).WithMany().HasForeignKey(c => c.ClosedByUser);
            modelBuilder.Entity<FollowUpReferral>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FollowUpReferral>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<FollowUpReferral>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<FollowUpReferral>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<FollowUpReferral>().HasOne(a => a.ReferredToId_Contact).WithMany().HasForeignKey(c => c.ReferredToId);
            modelBuilder.Entity<FollowUpReferral>().HasOne(a => a.FollowUpUnit_UOM).WithMany().HasForeignKey(c => c.FollowUpUnit);
            modelBuilder.Entity<VisitWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitWorkflowActivityHistory>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<VisitWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<InvestigationTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationTemplateParameter>().HasOne(a => a.InvestigationTemplate_InvestigationTemplate).WithMany().HasForeignKey(c => c.InvestigationTemplate);
            modelBuilder.Entity<InvestigationTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<InvestigationTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ChiefComplaintDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintDeviation>().HasOne(a => a.ChiefComplaint_ChiefComplaint).WithMany().HasForeignKey(c => c.ChiefComplaint);
            modelBuilder.Entity<ChiefComplaintDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ChiefComplaintDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ChiefComplaintDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<VisitDiagnosisNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitDiagnosisNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitDiagnosisNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitDiagnosisNotes>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.Medication_Medication).WithMany().HasForeignKey(c => c.Medication);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.DosageForm_UomInFormulation).WithMany().HasForeignKey(c => c.DosageForm);
            modelBuilder.Entity<TenantSubscriptionAdditionalUser>().HasOne(a => a.TenantSubscriptionId_TenantSubscription).WithMany().HasForeignKey(c => c.TenantSubscriptionId);
            modelBuilder.Entity<GeneralExamTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GeneralExamTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GeneralExamTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientEnrollmentLink>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientEnrollmentLink>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientEnrollmentLink>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<DefaultFormatForShortDate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DefaultFormatForShortDate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DefaultFormatForShortDate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTakeInitiated>().HasOne(a => a.StockTakeId_StockTake).WithMany().HasForeignKey(c => c.StockTakeId);
            modelBuilder.Entity<StockTakeInitiated>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<StockTakeInitiated>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<ChiefComplaint>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaint>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ChiefComplaint>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ChiefComplaint>().HasOne(a => a.ChiefComplaintTemplate_ChiefComplaintTemplate).WithMany().HasForeignKey(c => c.ChiefComplaintTemplate);
            modelBuilder.Entity<DataImport>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DataImport>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DataImport>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SpecialityPersonalisationCountry>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationCountry>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<SpecialityPersonalisationCountry>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<MedicationVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeatureParameter>().HasOne(a => a.TenantSubscriptionLineSubGroupFeature_TenantSubscriptionLineSubGroupFeature).WithMany().HasForeignKey(c => c.TenantSubscriptionLineSubGroupFeature);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeatureParameter>().HasOne(a => a.PackageLineSubGroupFeatureParameter_PackageLineSubGroupFeatureParameter).WithMany().HasForeignKey(c => c.PackageLineSubGroupFeatureParameter);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeatureParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeatureParameter>().HasOne(a => a.ClinicalParameterValue_ClinicalParameterValue).WithMany().HasForeignKey(c => c.ClinicalParameterValue);
            modelBuilder.Entity<TenantSubscriptionLineSubGroupFeatureParameter>().HasOne(a => a.UOM_UOM).WithMany().HasForeignKey(c => c.UOM);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.DayVisitId_DayVisit).WithMany().HasForeignKey(c => c.DayVisitId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ClinicType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ClinicType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ClinicType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DefaultFormatForShortTime>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DefaultFormatForShortTime>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DefaultFormatForShortTime>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductPaymentPlan>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductPaymentPlan>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductPaymentPlan>().HasOne(a => a.DurationUomId_UOM).WithMany().HasForeignKey(c => c.DurationUomId);
            modelBuilder.Entity<ProductPaymentPlan>().HasOne(a => a.ReferenceProductPaymentId_ProductPaymentPlan).WithMany().HasForeignKey(c => c.ReferenceProductPaymentId);
            modelBuilder.Entity<ProductPaymentPlan>().HasOne(a => a.ProductScheduleId_ProductSchedule).WithMany().HasForeignKey(c => c.ProductScheduleId);
            modelBuilder.Entity<AiProcess>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AiProcess>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AiProcess>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AiProcess>().HasOne(a => a.AiProcessTemplateId_AiProcessTemplate).WithMany().HasForeignKey(c => c.AiProcessTemplateId);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.VisitDiagnosis_VisitDiagnosis).WithMany().HasForeignKey(c => c.VisitDiagnosis);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CoverCategoryClinicExclusion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CoverCategoryClinicExclusion>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<CoverCategoryClinicExclusion>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<GeneralExam>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GeneralExam>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GeneralExam>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<FollowupResult>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FollowupResult>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<FollowupResult>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RoleEntity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleEntity>().HasOne(a => a.EntityId_Entity).WithMany().HasForeignKey(c => c.EntityId);
            modelBuilder.Entity<RoleEntity>().HasOne(a => a.RoleId_Role).WithMany().HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<RoleEntity>().HasOne(a => a.PackageLineId_PackageLine).WithMany().HasForeignKey(c => c.PackageLineId);
            modelBuilder.Entity<AllergyTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AllergyTemplateParameter>().HasOne(a => a.AllergyTemplate_AllergyTemplate).WithMany().HasForeignKey(c => c.AllergyTemplate);
            modelBuilder.Entity<AllergyTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<AllergyTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AllergyTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.SubReasonId_SubReason).WithMany().HasForeignKey(c => c.SubReasonId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.GoodsReceiptId_GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.SupplierId_Contact).WithMany().HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.PriceListId_PriceList).WithMany().HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<StockTransferSummary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTransferSummary>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockTransferSummary>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<StockTransferSummary>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<DosageForm>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DosageForm>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DosageForm>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SpecialityPersonalisationSpeciality>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationSpeciality>().HasOne(a => a.SpecialityId_Speciality).WithMany().HasForeignKey(c => c.SpecialityId);
            modelBuilder.Entity<SpecialityPersonalisationSpeciality>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<DoctorInvestigationProfileItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorInvestigationProfileItem>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorInvestigationProfileItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorInvestigationProfileItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Location>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Location>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Location>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<Location>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Location>().HasOne(a => a.StateId_State).WithMany().HasForeignKey(c => c.StateId);
            modelBuilder.Entity<Location>().HasOne(a => a.CityId_City).WithMany().HasForeignKey(c => c.CityId);
            modelBuilder.Entity<PatientEnrollmentTenantSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientEnrollmentTenantSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientEnrollmentTenantSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<FinanceSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<FinanceSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FinanceSettings>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<FinanceSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CoverCategoryProductExclusion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CoverCategoryProductExclusion>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<CoverCategoryProductExclusion>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<VisitTaskResult>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitTaskResult>().HasOne(a => a.VisitTaskId_VisitTask).WithMany().HasForeignKey(c => c.VisitTaskId);
            modelBuilder.Entity<VisitTaskResult>().HasOne(a => a.FollowUpResultId_FollowupResult).WithMany().HasForeignKey(c => c.FollowUpResultId);
            modelBuilder.Entity<VisitTaskResult>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitTaskResult>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Language>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Language>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Language>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PrescriptionLanguages>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PrescriptionLanguages>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<PrescriptionLanguages>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PrescriptionLanguages>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureVector>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureVector>().HasOne(a => a.ProcedureId_Procedure).WithMany().HasForeignKey(c => c.ProcedureId);
            modelBuilder.Entity<VendorGroup>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VendorGroup>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VendorGroup>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InformationObjects>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InformationObjects>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InformationObjects>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Product>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Product>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Product>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductCategoryId_ProductCategory).WithMany().HasForeignKey(c => c.ProductCategoryId);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductManufactureId_ProductManufacture).WithMany().HasForeignKey(c => c.ProductManufactureId);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductFormulationId_ProductFormulation).WithMany().HasForeignKey(c => c.ProductFormulationId);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductClassificationId_ProductClassification).WithMany().HasForeignKey(c => c.ProductClassificationId);
            modelBuilder.Entity<Product>().HasOne(a => a.LowestUOM_UOM).WithMany().HasForeignKey(c => c.LowestUOM);
            modelBuilder.Entity<Product>().HasOne(a => a.GstCategory_GstSettings).WithMany().HasForeignKey(c => c.GstCategory);
            modelBuilder.Entity<Product>().HasOne(a => a.ReOrderQuantityUom_ProductUom).WithMany().HasForeignKey(c => c.ReOrderQuantityUom);
            modelBuilder.Entity<Product>().HasOne(a => a.DrugScheduleId_DrugSchedule).WithMany().HasForeignKey(c => c.DrugScheduleId);
            modelBuilder.Entity<Product>().HasOne(a => a.FormulationId_Formulation).WithMany().HasForeignKey(c => c.FormulationId);
            modelBuilder.Entity<Product>().HasOne(a => a.InvestigationId_Investigation).WithMany().HasForeignKey(c => c.InvestigationId);
            modelBuilder.Entity<Product>().HasOne(a => a.ProcedureId_Procedure).WithMany().HasForeignKey(c => c.ProcedureId);
            modelBuilder.Entity<Product>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<Product>().HasOne(a => a.GenderId_Gender).WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<Product>().HasOne(a => a.PackageExpiryDurationUomId_UOM).WithMany().HasForeignKey(c => c.PackageExpiryDurationUomId);
            modelBuilder.Entity<MedicalCertificateFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicalCertificateFile>().HasOne(a => a.MedicalCertificateId_VisitMedicalCertificate).WithMany().HasForeignKey(c => c.MedicalCertificateId);
            modelBuilder.Entity<MedicalCertificateFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicalCertificateFile>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<DiagnosisDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DiagnosisDeviation>().HasOne(a => a.Diagnosis_Diagnosis).WithMany().HasForeignKey(c => c.Diagnosis);
            modelBuilder.Entity<DiagnosisDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DiagnosisDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DiagnosisDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<StockTransferFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTransferFile>().HasOne(a => a.StockTransferId_StockTransfer).WithMany().HasForeignKey(c => c.StockTransferId);
            modelBuilder.Entity<StockTransferFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroup>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroup>().HasOne(a => a.VisitExaminationTemplateSectionId_VisitExaminationTemplateSection).WithMany().HasForeignKey(c => c.VisitExaminationTemplateSectionId);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroup>().HasOne(a => a.VisitExaminationTemplateSectionColumnId_VisitExaminationTemplateSectionColumn).WithMany().HasForeignKey(c => c.VisitExaminationTemplateSectionColumnId);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroup>().HasOne(a => a.UOM_UOM).WithMany().HasForeignKey(c => c.UOM);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.PriceListId_PriceList).WithMany().HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.SupplierId_Contact).WithMany().HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<ComorbidityTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ComorbidityTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<ComorbidityTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ComorbidityTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AiProviderSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AiProviderSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AiProviderSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SpecialityPersonalisationChiefComplaint>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationChiefComplaint>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationChiefComplaint>().HasOne(a => a.ChiefComplaintId_ChiefComplaint).WithMany().HasForeignKey(c => c.ChiefComplaintId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.StockAdjustmentId_StockAdjustment).WithMany().HasForeignKey(c => c.StockAdjustmentId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.SubReasonId_SubReason).WithMany().HasForeignKey(c => c.SubReasonId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<VisitChiefComplaintNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitChiefComplaintNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitChiefComplaintNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitChiefComplaintNotes>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<PatientLifeStyle>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientLifeStyle>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientLifeStyle>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientLifeStyle>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientLifeStyle>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<MedicationDosageFormat>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationDosageFormat>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationDosageFormat>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ZohoIntegration>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorDiagnosis>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorDiagnosis>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorDiagnosis>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorDiagnosis>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ClinicalParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ClinicalParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ClinicalParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicalCertificateOrder>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicalCertificateOrder>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<MedicalCertificateOrder>().HasOne(a => a.VisitMedicalCertificateId_VisitMedicalCertificate).WithMany().HasForeignKey(c => c.VisitMedicalCertificateId);
            modelBuilder.Entity<MedicalCertificateOrder>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicalCertificateOrder>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicalCertificateOrder>().HasOne(a => a.InvoiceLineId_InvoiceLine).WithMany().HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<ShortFrequencyValueTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ShortFrequencyValueTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<ShortFrequencyValueTranslation>().HasOne(a => a.MedicationShortFrequencyId_MedicationShortFrequency).WithMany().HasForeignKey(c => c.MedicationShortFrequencyId);
            modelBuilder.Entity<ShortFrequencyValueTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ShortFrequencyValueTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Covid19HistoryChoiceTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Covid19HistoryChoiceTemplateParameter>().HasOne(a => a.Covid19HistoryChoiceTemplate_Covid19HistoryChoiceTemplate).WithMany().HasForeignKey(c => c.Covid19HistoryChoiceTemplate);
            modelBuilder.Entity<Covid19HistoryChoiceTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<Covid19HistoryChoiceTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Covid19HistoryChoiceTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SpecialityPersonalisationDiagnosis>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationDiagnosis>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationDiagnosis>().HasOne(a => a.DiagnosisId_Diagnosis).WithMany().HasForeignKey(c => c.DiagnosisId);
            modelBuilder.Entity<PrescriptionFiles>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PrescriptionFiles>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PrescriptionFiles>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<PrescriptionFiles>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.GoodsReturnId_GoodsReturn).WithMany().HasForeignKey(c => c.GoodsReturnId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.GoodsReceiptItemId_GoodsReceiptItem).WithMany().HasForeignKey(c => c.GoodsReceiptItemId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.SubReasonId_SubReason).WithMany().HasForeignKey(c => c.SubReasonId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.InvoiceLineId_InvoiceLine).WithMany().HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.SublocationId_SubLocation).WithMany().HasForeignKey(c => c.SublocationId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<PatientEnrolledPackage>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<MedicationInstructionTranslationDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationInstructionTranslationDeviation>().HasOne(a => a.MedicationInstructionTranslationId_MedicationInstructionTranslation).WithMany().HasForeignKey(c => c.MedicationInstructionTranslationId);
            modelBuilder.Entity<MedicationInstructionTranslationDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<GuideLineDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GuideLineDeviation>().HasOne(a => a.GuideLine_Guideline).WithMany().HasForeignKey(c => c.GuideLine);
            modelBuilder.Entity<GuideLineDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GuideLineDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GuideLineDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<SMS>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SMS>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<SMS>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Payment>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Payment>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Payment>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<Payment>().HasOne(a => a.Invoice_Invoice).WithMany().HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<Payment>().HasOne(a => a.PaymentMode_PaymentMode).WithMany().HasForeignKey(c => c.PaymentMode);
            modelBuilder.Entity<Payment>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Payment>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PatientPatientCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientPatientCategory>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientPatientCategory>().HasOne(a => a.PatientCategoryId_PatientCategory).WithMany().HasForeignKey(c => c.PatientCategoryId);
            modelBuilder.Entity<PatientPatientCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientPatientCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RoleOperationScope>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleOperationScope>().HasOne(a => a.RoleOperationId_RoleOperation).WithMany().HasForeignKey(c => c.RoleOperationId);
            modelBuilder.Entity<Lab>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Lab>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Lab>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitGeneralExamParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitGeneralExamParameter>().HasOne(a => a.VisitGeneralExam_VisitGeneralExam).WithMany().HasForeignKey(c => c.VisitGeneralExam);
            modelBuilder.Entity<VisitGeneralExamParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitGeneralExamParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Email>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Email>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Email>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Procedure>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Procedure>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Procedure>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Procedure>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Procedure>().HasOne(a => a.ProcedureTemplate_ProcedureTemplate).WithMany().HasForeignKey(c => c.ProcedureTemplate);
            modelBuilder.Entity<InformationObjectFields>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InformationObjectFields>().HasOne(a => a.InformationObjectId_InformationObjects).WithMany().HasForeignKey(c => c.InformationObjectId);
            modelBuilder.Entity<InformationObjectFields>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InformationObjectFields>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SmsGatewayType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SmsGatewayType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SmsGatewayType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<LoginHistory>().HasOne(a => a.Tenantid_Tenant).WithMany().HasForeignKey(c => c.Tenantid);
            modelBuilder.Entity<LoginHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<PatientAllergy>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientAllergy>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientAllergy>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientAllergy>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientAllergy>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<SpecialityPersonalisationProcedure>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationProcedure>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationProcedure>().HasOne(a => a.ProcedureId_Procedure).WithMany().HasForeignKey(c => c.ProcedureId);
            modelBuilder.Entity<InvoiceFiles>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvoiceFiles>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvoiceFiles>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<EcCoinRules>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EcCoinRules>().HasOne(a => a.CurrencyId_Currency).WithMany().HasForeignKey(c => c.CurrencyId);
            modelBuilder.Entity<EcCoinRules>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<InvestigationProfileItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationProfileItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationProfileItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GeneralExamTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GeneralExamTemplateParameter>().HasOne(a => a.GeneralExamTemplate_GeneralExamTemplate).WithMany().HasForeignKey(c => c.GeneralExamTemplate);
            modelBuilder.Entity<GeneralExamTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<GeneralExamTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GeneralExamTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Generic>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EmailStatus>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EmailStatus>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<EmailStatus>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.GoodsReceiptId_GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.ReplacedProductId_Product).WithMany().HasForeignKey(c => c.ReplacedProductId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.PurchaseOrderId_PurchaseOrder).WithMany().HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.PurchaseOrderLineId_PurchaseOrderLine).WithMany().HasForeignKey(c => c.PurchaseOrderLineId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<DiagnosisTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DiagnosisTemplateParameter>().HasOne(a => a.DiagnosisTemplate_DiagnosisTemplate).WithMany().HasForeignKey(c => c.DiagnosisTemplate);
            modelBuilder.Entity<DiagnosisTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<DiagnosisTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DiagnosisTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationDeviation>().HasOne(a => a.Investigation_Investigation).WithMany().HasForeignKey(c => c.Investigation);
            modelBuilder.Entity<InvestigationDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<CountryCode>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CountryCode>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CountryCode>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CountryCode>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<CommunicationTemplateVariable>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationTemplateVariable>().HasOne(a => a.CommunicationTemplateId_CommunicationTemplate).WithMany().HasForeignKey(c => c.CommunicationTemplateId);
            modelBuilder.Entity<ReferredBy>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReferredBy>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ReferredBy>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<EmailTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EmailTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<EmailTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<State>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<State>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<State>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<State>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<LocationStockBalance>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<LocationStockBalance>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<LocationStockBalance>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<SpecialityPersonalisationInvestigation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationInvestigation>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationInvestigation>().HasOne(a => a.InvestigationId_Investigation).WithMany().HasForeignKey(c => c.InvestigationId);
            modelBuilder.Entity<EcCoinBenefit>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EcCoinBenefit>().HasOne(a => a.CurrencyId_Currency).WithMany().HasForeignKey(c => c.CurrencyId);
            modelBuilder.Entity<EcCoinBenefit>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<ChatAssistantSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChatAssistantSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ChatAssistantSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationOrderLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationOrderLine>().HasOne(a => a.InvestigationOrderId_InvestigationOrder).WithMany().HasForeignKey(c => c.InvestigationOrderId);
            modelBuilder.Entity<InvestigationOrderLine>().HasOne(a => a.VisitInvestigationId_VisitInvestigation).WithMany().HasForeignKey(c => c.VisitInvestigationId);
            modelBuilder.Entity<InvestigationOrderLine>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationOrderLine>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationOrderLine>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<InformationObjectsRules>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InformationObjectsRules>().HasOne(a => a.InformationObjectId_InformationObjects).WithMany().HasForeignKey(c => c.InformationObjectId);
            modelBuilder.Entity<Entities.File>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entities.File>().HasOne(a => a.BinaryFileId_FileBinary).WithMany().HasForeignKey(c => c.BinaryFileId);
            modelBuilder.Entity<Entities.File>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Entities.File>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Entities.File>().HasOne(a => a.LabId_Contact).WithMany().HasForeignKey(c => c.LabId);
            modelBuilder.Entity<Entities.File>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<DoctorChiefComplaint>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorChiefComplaint>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorChiefComplaint>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorChiefComplaint>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.DispenseId_Dispense).WithMany().HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.VisitMedicationId_VisitMedication).WithMany().HasForeignKey(c => c.VisitMedicationId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<CommunicationModuleEventRelation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.StockTransferId_StockTransfer).WithMany().HasForeignKey(c => c.StockTransferId);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<StockTransferItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<Week>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Week>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicationShortFrequency>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationShortFrequency>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationShortFrequency>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.ContactMemberId_ContactMember).WithMany().HasForeignKey(c => c.ContactMemberId);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VitalTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VitalTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VitalTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PriceListVersionItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PriceListVersionItem>().HasOne(a => a.Id_PriceListVersionItem).WithMany().HasForeignKey(c => c.Id);
            modelBuilder.Entity<PriceListVersionItem>().HasOne(a => a.PriceListId_PriceList).WithMany().HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListVersionItem>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PriceListVersionItem>().HasOne(a => a.PriceListVersionId_PriceListVersion).WithMany().HasForeignKey(c => c.PriceListVersionId);
            modelBuilder.Entity<PriceListVersionItem>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InformationObjectsRuleFields>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InformationObjectsRuleFields>().HasOne(a => a.InformationObjectRuleId_InformationObjectsRules).WithMany().HasForeignKey(c => c.InformationObjectRuleId);
            modelBuilder.Entity<LifeStyleChoiceTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<LifeStyleChoiceTemplateParameter>().HasOne(a => a.LifeStyleChoiceTemplate_LifeStyleChoiceTemplate).WithMany().HasForeignKey(c => c.LifeStyleChoiceTemplate);
            modelBuilder.Entity<LifeStyleChoiceTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<LifeStyleChoiceTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<LifeStyleChoiceTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.PurchaseOrderId_PurchaseOrder).WithMany().HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.PurchaseOrderLineId_PurchaseOrderLine).WithMany().HasForeignKey(c => c.PurchaseOrderLineId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.SupplierId_Contact).WithMany().HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasOne(a => a.InvestigationOrderId_InvestigationOrder).WithMany().HasForeignKey(c => c.InvestigationOrderId);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasOne(a => a.InvestigationOrderLineId_InvestigationOrderLine).WithMany().HasForeignKey(c => c.InvestigationOrderLineId);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationOrderWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<MedicationNotesTranslationDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationNotesTranslationDeviation>().HasOne(a => a.MedicationNotesTranslationId_MedicationNotesTranslation).WithMany().HasForeignKey(c => c.MedicationNotesTranslationId);
            modelBuilder.Entity<MedicationNotesTranslationDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<SpecialityPersonalisationMedication>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationMedication>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<PatientAllergyParameterValue>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientAllergyParameterValue>().HasOne(a => a.ClinicalParameterValue_ClinicalParameterValue).WithMany().HasForeignKey(c => c.ClinicalParameterValue);
            modelBuilder.Entity<Report>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Report>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Report>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CommunicationFields>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OrganisationStockBalance>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OrganisationStockBalance>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<EnrolledProgramReward>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EnrolledProgramReward>().HasOne(a => a.EnrolledProgramId_EnrolledProgram).WithMany().HasForeignKey(c => c.EnrolledProgramId);
            modelBuilder.Entity<EnrolledProgramReward>().HasOne(a => a.EnrolledProgramDetailId_EnrolledProgramDetails).WithMany().HasForeignKey(c => c.EnrolledProgramDetailId);
            modelBuilder.Entity<EnrolledProgramReward>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitClinicalInternalNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitClinicalInternalNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitClinicalInternalNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitClinicalInternalNotes>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<PackageLine>().HasOne(a => a.PackageId_Package).WithMany().HasForeignKey(c => c.PackageId);
            modelBuilder.Entity<GuidelineTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GuidelineTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<GuidelineTranslation>().HasOne(a => a.GuidelineId_Guideline).WithMany().HasForeignKey(c => c.GuidelineId);
            modelBuilder.Entity<GuidelineTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GuidelineTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ReferredTo>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReferredTo>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ReferredTo>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<OrganizationSettingsFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OrganizationSettingsFile>().HasOne(a => a.OrganizationId_OrganizationSettings).WithMany().HasForeignKey(c => c.OrganizationId);
            modelBuilder.Entity<OrganizationSettingsFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitTypeLocation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitTypeLocation>().HasOne(a => a.VisitTypeId_VisitType).WithMany().HasForeignKey(c => c.VisitTypeId);
            modelBuilder.Entity<VisitTypeLocation>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<UserAccessLocation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserAccessLocation>().HasOne(a => a.Location_Location).WithMany().HasForeignKey(c => c.Location);
            modelBuilder.Entity<UserAccessLocation>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<GuidelineTranslationDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GuidelineTranslationDeviation>().HasOne(a => a.GuideLineTranslationId_GuidelineTranslation).WithMany().HasForeignKey(c => c.GuideLineTranslationId);
            modelBuilder.Entity<GuidelineTranslationDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<AllergyTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AllergyTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AllergyTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UomInFormulation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UomInFormulation>().HasOne(a => a.Formulation_Formulation).WithMany().HasForeignKey(c => c.Formulation);
            modelBuilder.Entity<UomInFormulation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UomInFormulation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UomInFormulation>().HasOne(a => a.Uom_UOM).WithMany().HasForeignKey(c => c.Uom);
            modelBuilder.Entity<DependentInformationObjects>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DependentInformationObjects>().HasOne(a => a.InformationObjectId_InformationObjects).WithMany().HasForeignKey(c => c.InformationObjectId);
            modelBuilder.Entity<DependentInformationObjects>().HasOne(a => a.DependentInformationObjectId_InformationObjects).WithMany().HasForeignKey(c => c.DependentInformationObjectId);
            modelBuilder.Entity<Entity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entity>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UserBankDetails>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserBankDetails>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserBankDetails>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserBankDetails>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SpecialityPersonalisationExaminationTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationExaminationTemplate>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationExaminationTemplate>().HasOne(a => a.ExaminationTemplateId_ExaminationTemplate).WithMany().HasForeignKey(c => c.ExaminationTemplateId);
            modelBuilder.Entity<DrugSchedule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugSchedule>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugSchedule>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CredentialHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CredentialHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CredentialHistory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.DispenseItemId_DispenseItem).WithMany().HasForeignKey(c => c.DispenseItemId);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.DosageFormId_UomInFormulation).WithMany().HasForeignKey(c => c.DosageFormId);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.MedicationInstructionId_MedicationInstruction).WithMany().HasForeignKey(c => c.MedicationInstructionId);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.UomId_UOM).WithMany().HasForeignKey(c => c.UomId);
            modelBuilder.Entity<VisitTypeCheckList>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitTypeCheckList>().HasOne(a => a.VisitTypeId_VisitType).WithMany().HasForeignKey(c => c.VisitTypeId);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasOne(a => a.Medication_Medication).WithMany().HasForeignKey(c => c.Medication);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.DefaultCurrencyId_Currency).WithMany().HasForeignKey(c => c.DefaultCurrencyId);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.DefaultLanguageId_Language).WithMany().HasForeignKey(c => c.DefaultLanguageId);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.LongDateFormatId_DefaultFormatForLongDate).WithMany().HasForeignKey(c => c.LongDateFormatId);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.ShortDateFormatId_DefaultFormatForShortDate).WithMany().HasForeignKey(c => c.ShortDateFormatId);
            modelBuilder.Entity<TenantCulture>().HasOne(a => a.Timezone_Timezone).WithMany().HasForeignKey(c => c.Timezone);
            modelBuilder.Entity<ProcedureTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProcedureTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureTemplateParameter>().HasOne(a => a.ProcedureTemplate_ProcedureTemplate).WithMany().HasForeignKey(c => c.ProcedureTemplate);
            modelBuilder.Entity<ProcedureTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<CommunicationMeter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.InvoiceLineId_InvoiceLine).WithMany().HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<InformationObjectVersions>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InformationObjectVersions>().HasOne(a => a.InformationObjectId_InformationObjects).WithMany().HasForeignKey(c => c.InformationObjectId);
            modelBuilder.Entity<UOM>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UOM>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UOM>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.Uom_UOM).WithMany().HasForeignKey(c => c.Uom);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SpecialityPersonalisationComorbidity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationComorbidity>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationComorbidity>().HasOne(a => a.ComorbidityId_Comorbidity).WithMany().HasForeignKey(c => c.ComorbidityId);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.SupplierId_Contact).WithMany().HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<DoctorReport>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorReport>().HasOne(a => a.ReportId_Report).WithMany().HasForeignKey(c => c.ReportId);
            modelBuilder.Entity<DoctorReport>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<DoctorReport>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorReport>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CommunicationTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CommunicationTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Entities.Route>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entities.Route>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Entities.Route>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UserHoliday>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserHoliday>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserHoliday>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserHoliday>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InformationObjectFieldSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InformationObjectFieldSettings>().HasOne(a => a.InformationObjectFieldId_InformationObjectFields).WithMany().HasForeignKey(c => c.InformationObjectFieldId);
            modelBuilder.Entity<TenantSubscription>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSubscription>().HasOne(a => a.PackageId_Package).WithMany().HasForeignKey(c => c.PackageId);
            modelBuilder.Entity<TenantSubscription>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<TenantSubscription>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AgeUnit>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AgeUnit>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AgeUnit>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DispenseFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DispenseFile>().HasOne(a => a.DispenseId_Dispense).WithMany().HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<DispenseFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DispenseFile>().HasOne(a => a.DispenseItemId_DispenseItem).WithMany().HasForeignKey(c => c.DispenseItemId);
            modelBuilder.Entity<DiagnosisSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationAllergy>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationAllergy>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationAllergy>().HasOne(a => a.AllergyId_Allergy).WithMany().HasForeignKey(c => c.AllergyId);
            modelBuilder.Entity<VisitVitalParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitVitalParameter>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitVitalParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitVitalParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<SubscriptionCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SubscriptionCategory>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<SubscriptionCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<SubscriptionCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<FileBinary>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.ReferralOrderId_ReferralOrder).WithMany().HasForeignKey(c => c.ReferralOrderId);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.VisitReferralId_VisitReferral).WithMany().HasForeignKey(c => c.VisitReferralId);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.ReferredToId_Contact).WithMany().HasForeignKey(c => c.ReferredToId);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ReferralOrderLine>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<VitalTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VitalTemplateParameter>().HasOne(a => a.VitalTemplate_VitalTemplate).WithMany().HasForeignKey(c => c.VitalTemplate);
            modelBuilder.Entity<VitalTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<VitalTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VitalTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InventorySettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InventorySettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InventorySettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicationNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<City>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<City>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<City>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<City>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.SupplierId_Contact).WithMany().HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.OrderBy_User).WithMany().HasForeignKey(c => c.OrderBy);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Investigation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Investigation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Investigation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Investigation>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Investigation>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<Investigation>().HasOne(a => a.InvestigationTemplate_InvestigationTemplate).WithMany().HasForeignKey(c => c.InvestigationTemplate);
            modelBuilder.Entity<CoverCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CoverCategory>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<CoverCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CoverCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientLifeStyleParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientLifeStyleParameter>().HasOne(a => a.PatientLifeStyle_PatientLifeStyle).WithMany().HasForeignKey(c => c.PatientLifeStyle);
            modelBuilder.Entity<PatientLifeStyleParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientLifeStyleParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<User>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<User>().HasOne(a => a.Id_User).WithMany().HasForeignKey(c => c.Id);
            modelBuilder.Entity<User>().HasOne(a => a.Speciality_Speciality).WithMany().HasForeignKey(c => c.Speciality);
            modelBuilder.Entity<User>().HasOne(a => a.TitleId_Title).WithMany().HasForeignKey(c => c.TitleId);
            modelBuilder.Entity<User>().HasOne(a => a.PreferredLanguageId_Language).WithMany().HasForeignKey(c => c.PreferredLanguageId);
            modelBuilder.Entity<ExaminationSectionGroup>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ExaminationSectionGroup>().HasOne(a => a.ExaminationSectionId_ExaminationSection).WithMany().HasForeignKey(c => c.ExaminationSectionId);
            modelBuilder.Entity<ExaminationSectionGroup>().HasOne(a => a.ClinicalParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Dispense>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Dispense>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<MedicationSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSubscriptionLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSubscriptionLine>().HasOne(a => a.TenantSubscriptionId_TenantSubscription).WithMany().HasForeignKey(c => c.TenantSubscriptionId);
            modelBuilder.Entity<TenantSubscriptionLine>().HasOne(a => a.PackageLine_PackageLine).WithMany().HasForeignKey(c => c.PackageLine);
            modelBuilder.Entity<VisitInvestigationRecurrence>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitInvestigationRecurrence>().HasOne(a => a.VisitInvestigationId_VisitInvestigation).WithMany().HasForeignKey(c => c.VisitInvestigationId);
            modelBuilder.Entity<VisitInvestigationRecurrence>().HasOne(a => a.RecurringPatternUnit_UOM).WithMany().HasForeignKey(c => c.RecurringPatternUnit);
            modelBuilder.Entity<VisitInvestigationRecurrence>().HasOne(a => a.EndDateUnit_UOM).WithMany().HasForeignKey(c => c.EndDateUnit);
            modelBuilder.Entity<SpecialityPersonalisationComponent>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationComponent>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<FrequencyValue>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FrequencyValue>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<FrequencyValue>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GuidelineSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantInvoicePayment>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantInvoicePayment>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<TenantInvoicePayment>().HasOne(a => a.InvoiceId_TenantInvoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<AiMeter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationModuleEventTemplateRelation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationModuleEventTemplateRelation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CommunicationModuleEventTemplateRelation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.GenderId_Gender).WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.AgeUnitId_AgeUnit).WithMany().HasForeignKey(c => c.AgeUnitId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.StateId_State).WithMany().HasForeignKey(c => c.StateId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.CityId_City).WithMany().HasForeignKey(c => c.CityId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.SubscriptionCategoryId_SubscriptionCategory).WithMany().HasForeignKey(c => c.SubscriptionCategoryId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.NationalTypeId_NationalIdType).WithMany().HasForeignKey(c => c.NationalTypeId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.TitleId_Title).WithMany().HasForeignKey(c => c.TitleId);
            modelBuilder.Entity<FileSetting>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FileSetting>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<FileSetting>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GuidelineGroupItem>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GuidelineGroupItem>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<GuidelineGroupItem>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<GuidelineGroupItem>().HasOne(a => a.GuidelineId_Guideline).WithMany().HasForeignKey(c => c.GuidelineId);
            modelBuilder.Entity<ReportDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReportDeviation>().HasOne(a => a.ReportId_Report).WithMany().HasForeignKey(c => c.ReportId);
            modelBuilder.Entity<ReportDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ReportDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvoiceTaxBreakup>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvoiceTaxBreakup>().HasOne(a => a.Invoice_Invoice).WithMany().HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<StockTake>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTake>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<StockTake>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockTake>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTake>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<CommunicationVerification>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintTemplateParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintTemplateParameter>().HasOne(a => a.ChiefComplaintTemplate_ChiefComplaintTemplate).WithMany().HasForeignKey(c => c.ChiefComplaintTemplate);
            modelBuilder.Entity<ChiefComplaintTemplateParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<ChiefComplaintTemplateParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ChiefComplaintTemplateParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DoctorComorbidity>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorComorbidity>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorComorbidity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorComorbidity>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<TemplateComponentParameters>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TemplateComponentParameters>().HasOne(a => a.TemplateComponentId_TemplateComponents).WithMany().HasForeignKey(c => c.TemplateComponentId);
            modelBuilder.Entity<TemplateComponentParameters>().HasOne(a => a.ClinicalParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<ProductRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductRule>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<ProductRule>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductRule>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductRule>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProducedType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProducedType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProducedType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<EntityVectorConfiguration>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ExaminationSectionGroupParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ExaminationSectionGroupParameter>().HasOne(a => a.ExaminationSectionGroupId_ExaminationSectionGroup).WithMany().HasForeignKey(c => c.ExaminationSectionGroupId);
            modelBuilder.Entity<ExaminationSectionGroupParameter>().HasOne(a => a.ClinicalParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<SpecialityPersonalisationDruglist>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<SpecialityPersonalisationDruglist>().HasOne(a => a.SpecialityPersonalisationId_SpecialityPersonalisation).WithMany().HasForeignKey(c => c.SpecialityPersonalisationId);
            modelBuilder.Entity<SpecialityPersonalisationDruglist>().HasOne(a => a.DruglistId_DrugList).WithMany().HasForeignKey(c => c.DruglistId);
            modelBuilder.Entity<MedicationInstruction>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationInstruction>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationInstruction>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureOrder>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureOrder>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<ProcedureOrder>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProcedureOrder>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<IntegrationUserToken>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<IntegrationUserToken>().HasOne(a => a.IntegrationUserId_IntegrationUser).WithMany().HasForeignKey(c => c.IntegrationUserId);
            modelBuilder.Entity<DoctorInvestigation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorInvestigation>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorInvestigation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorInvestigation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.VisitChiefComplaint_VisitChiefComplaint).WithMany().HasForeignKey(c => c.VisitChiefComplaint);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationOrder>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationOrder>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<InvestigationOrder>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationOrder>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationOrder>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<ReportAccess>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReportAccess>().HasOne(a => a.ReportId_Report).WithMany().HasForeignKey(c => c.ReportId);
            modelBuilder.Entity<ReportAccess>().HasOne(a => a.AccessedBy_User).WithMany().HasForeignKey(c => c.AccessedBy);
            modelBuilder.Entity<DoctorAllergy>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorAllergy>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorAllergy>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorAllergy>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CommunicationEventTemplates>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationEventTemplates>().HasOne(a => a.CommunicationModuleEventTemplateRelation_CommunicationModuleEventTemplateRelation).WithMany().HasForeignKey(c => c.CommunicationModuleEventTemplateRelation);
            modelBuilder.Entity<CommunicationEventTemplates>().HasOne(a => a.CommunicationTemplateId_CommunicationTemplate).WithMany().HasForeignKey(c => c.CommunicationTemplateId);
            modelBuilder.Entity<Formulation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Formulation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Formulation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitInvestigationNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitInvestigationNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitInvestigationNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitInvestigationNotes>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<ExaminationTemplateSection>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ExaminationTemplateSection>().HasOne(a => a.ExaminationTemplateId_ExaminationTemplate).WithMany().HasForeignKey(c => c.ExaminationTemplateId);
            modelBuilder.Entity<ExaminationTemplateSection>().HasOne(a => a.ExaminationSectionId_ExaminationSection).WithMany().HasForeignKey(c => c.ExaminationSectionId);
            modelBuilder.Entity<EntityOperation>().HasOne(a => a.Entity_Entity).WithMany().HasForeignKey(c => c.Entity);
            modelBuilder.Entity<EntityOperation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<EntityOperation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EntityOperation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlow>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<WorkFlow>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<WorkFlow>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlow>().HasOne(a => a.VisitTypeId_VisitType).WithMany().HasForeignKey(c => c.VisitTypeId);
            modelBuilder.Entity<Guideline>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Guideline>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Guideline>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CommunicationContextType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationContextType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CommunicationContextType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DoctorProcedure>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<DoctorProcedure>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DoctorProcedure>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DoctorProcedure>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductGenderRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductGenderRule>().HasOne(a => a.ProductRuleId_ProductRule).WithMany().HasForeignKey(c => c.ProductRuleId);
            modelBuilder.Entity<ProductGenderRule>().HasOne(a => a.GenderId_Gender).WithMany().HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<PrescriptionFooter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PrescriptionFooter>().HasOne(a => a.TenantExtensionId_TenantExtension).WithMany().HasForeignKey(c => c.TenantExtensionId);
            modelBuilder.Entity<PrescriptionFooter>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Membership>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Membership>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Membership>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<EMRSuggestionLog>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EMRSuggestionLog>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<EMRSuggestionLog>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<EMRSuggestionLog>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<EMRSuggestionLog>().HasOne(a => a.ChiefComplaintId_ChiefComplaint).WithMany().HasForeignKey(c => c.ChiefComplaintId);
            modelBuilder.Entity<EMRSuggestionLog>().HasOne(a => a.DiagnosisId_Diagnosis).WithMany().HasForeignKey(c => c.DiagnosisId);
            modelBuilder.Entity<UserGoogleAuthorization>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserGoogleAuthorization>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<EmrTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<EmrTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EmrTemplate>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<EmrTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<EmrTemplate>().HasOne(a => a.VisitTypeId_VisitType).WithMany().HasForeignKey(c => c.VisitTypeId);
            modelBuilder.Entity<Speciality>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Speciality>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Speciality>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Tenant>().HasOne(a => a.Id_Tenant).WithMany().HasForeignKey(c => c.Id);
            modelBuilder.Entity<Tenant>().HasOne(a => a.ExtensionId_TenantExtension).WithMany().HasForeignKey(c => c.ExtensionId);
            modelBuilder.Entity<Tenant>().HasOne(a => a.AvatarId_Image).WithMany().HasForeignKey(c => c.AvatarId);
            modelBuilder.Entity<Tenant>().HasOne(a => a.SuperAdminId_User).WithMany().HasForeignKey(c => c.SuperAdminId);
            modelBuilder.Entity<Tenant>().HasOne(a => a.PreferredLanguageId_Language).WithMany().HasForeignKey(c => c.PreferredLanguageId);
            modelBuilder.Entity<Tenant>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Tenant>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<TenantDeleteOtp>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductUom>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductUom>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductUom>().HasOne(a => a.UomId_UOM).WithMany().HasForeignKey(c => c.UomId);
            modelBuilder.Entity<CommunicationLog>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationLog>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<CommunicationLog>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CommunicationLog>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CommunicationLog>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<CommunicationLog>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasOne(a => a.GoodsReceiptId_GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasOne(a => a.PurchaseOrderId_PurchaseOrder).WithMany().HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<AccountSettlement>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AccountSettlement>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<AccountSettlement>().HasOne(a => a.InvoiceId_Invoice).WithMany().HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<VisitChiefComplaint>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitChiefComplaint>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitChiefComplaint>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitChiefComplaint>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitWorkFlowStep>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Contact>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Contact>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Contact>().HasOne(a => a.TitleId_Title).WithMany().HasForeignKey(c => c.TitleId);
            modelBuilder.Entity<Contact>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Contact>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Contact>().HasOne(a => a.SpecialityId_Speciality).WithMany().HasForeignKey(c => c.SpecialityId);
            modelBuilder.Entity<Contact>().HasOne(a => a.StateId_State).WithMany().HasForeignKey(c => c.StateId);
            modelBuilder.Entity<Contact>().HasOne(a => a.CityId_City).WithMany().HasForeignKey(c => c.CityId);
            modelBuilder.Entity<Contact>().HasOne(a => a.CountryId_Country).WithMany().HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<CommunicationMode>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationMode>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CommunicationMode>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductPackage>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductPackage>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductPackage>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductPackage>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductPackage>().HasOne(a => a.ProductScheduleId_ProductSchedule).WithMany().HasForeignKey(c => c.ProductScheduleId);
            modelBuilder.Entity<ProductPatientCategoryRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductPatientCategoryRule>().HasOne(a => a.ProductRuleId_ProductRule).WithMany().HasForeignKey(c => c.ProductRuleId);
            modelBuilder.Entity<ProductPatientCategoryRule>().HasOne(a => a.PatientCategoryId_PatientCategory).WithMany().HasForeignKey(c => c.PatientCategoryId);
            modelBuilder.Entity<IcdCode>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FrequencyValueTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FrequencyValueTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<FrequencyValueTranslation>().HasOne(a => a.FrequencyValueId_FrequencyValue).WithMany().HasForeignKey(c => c.FrequencyValueId);
            modelBuilder.Entity<FrequencyValueTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<FrequencyValueTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Qualification>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Qualification>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Qualification>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitGeneralExam>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitGeneralExam>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitGeneralExam>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitGeneralExam>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlowStates>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AllergyDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AllergyDeviation>().HasOne(a => a.Allergy_Allergy).WithMany().HasForeignKey(c => c.Allergy);
            modelBuilder.Entity<AllergyDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<AllergyDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AllergyDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<TemplateComponents>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TemplateComponents>().HasOne(a => a.EmrTemplateId_EmrTemplate).WithMany().HasForeignKey(c => c.EmrTemplateId);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PurchaseOrderFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PurchaseOrderFile>().HasOne(a => a.PurchaseOrderId_PurchaseOrder).WithMany().HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.GenericId_Generic).WithMany().HasForeignKey(c => c.GenericId);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.UomId_UOM).WithMany().HasForeignKey(c => c.UomId);
            modelBuilder.Entity<CoverCategorySubscription>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CoverCategorySubscription>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<CoverCategorySubscription>().HasOne(a => a.SubscriptionCategoryId_SubscriptionCategory).WithMany().HasForeignKey(c => c.SubscriptionCategoryId);
            modelBuilder.Entity<ProductLocationPrice>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductLocationPrice>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<ProductLocationPrice>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductLocationPrice>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductLocationPrice>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Lifestyle>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Lifestyle>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Lifestyle>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ContactProductCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ContactProductCategory>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<ContactProductCategory>().HasOne(a => a.ProductCategoryId_ProductCategory).WithMany().HasForeignKey(c => c.ProductCategoryId);
            modelBuilder.Entity<ContactProductCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ContactProductCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Invoice>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Invoice>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<Invoice>().HasOne(a => a.CoverCategoryId_CoverCategory).WithMany().HasForeignKey(c => c.CoverCategoryId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.VoidReasonId_VoidReason).WithMany().HasForeignKey(c => c.VoidReasonId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.CreditInvoiceId_Invoice).WithMany().HasForeignKey(c => c.CreditInvoiceId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<Invoice>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Invoice>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.ReferredById_Contact).WithMany().HasForeignKey(c => c.ReferredById);
            modelBuilder.Entity<Invoice>().HasOne(a => a.PayorId_Contact).WithMany().HasForeignKey(c => c.PayorId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.PlaceOfSupply_State).WithMany().HasForeignKey(c => c.PlaceOfSupply);
            modelBuilder.Entity<StockTakeFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTakeFile>().HasOne(a => a.StockTakeId_StockTake).WithMany().HasForeignKey(c => c.StockTakeId);
            modelBuilder.Entity<StockTakeFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DiagnosisTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DiagnosisTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DiagnosisTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PackageLineSubGroup>().HasOne(a => a.PackageLine_PackageLine).WithMany().HasForeignKey(c => c.PackageLine);
            modelBuilder.Entity<NationalIdType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<NationalIdType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<NationalIdType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<FavouritePurchaseOrderLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FavouritePurchaseOrderLine>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<FavouritePurchaseOrderLine>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Settings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Settings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasOne(a => a.DoctorId_User).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<PatientAutoAppointmentLink>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<GoodsReceiptFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceiptFile>().HasOne(a => a.GoodsReceiptId_GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientEnrolledPackageSchedule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientEnrolledPackageSchedule>().HasOne(a => a.PatientEnrolledPackageId_PatientEnrolledPackage).WithMany().HasForeignKey(c => c.PatientEnrolledPackageId);
            modelBuilder.Entity<PatientEnrolledPackageSchedule>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<PatientEnrolledPackageSchedule>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<OtherMedicationTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OtherMedicationTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<OtherMedicationTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<OtherMedicationTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProcedureDeviation>().HasOne(a => a.Procedure_Procedure).WithMany().HasForeignKey(c => c.Procedure);
            modelBuilder.Entity<ProcedureDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProcedureDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProcedureDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<EntityFieldAuthorization>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RequisitionWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RequisitionWorkflowActivityHistory>().HasOne(a => a.RequisitionId_Requisition).WithMany().HasForeignKey(c => c.RequisitionId);
            modelBuilder.Entity<RequisitionWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<RequisitionWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RequisitionWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ProductManufacture>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductManufacture>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductManufacture>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ComorbidityTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ComorbidityTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ComorbidityTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Role>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Role>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlowTransitions>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<WorkFlowTransitions>().HasOne(a => a.WorkFlowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkFlowStateId);
            modelBuilder.Entity<TenantExtension>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantExtension>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<TenantExtension>().HasOne(a => a.AvatarId_Image).WithMany().HasForeignKey(c => c.AvatarId);
            modelBuilder.Entity<TenantExtension>().HasOne(a => a.DigitalSignatureId_Image).WithMany().HasForeignKey(c => c.DigitalSignatureId);
            modelBuilder.Entity<UserDrugList>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserDrugList>().HasOne(a => a.DrugListId_DrugList).WithMany().HasForeignKey(c => c.DrugListId);
            modelBuilder.Entity<UserDrugList>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<VisitMedicationRefill>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitMedicationRefill>().HasOne(a => a.VisitMedicationId_VisitMedication).WithMany().HasForeignKey(c => c.VisitMedicationId);
            modelBuilder.Entity<VisitMedicationRefill>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitMedicationRefill>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.Investigation_Investigation).WithMany().HasForeignKey(c => c.Investigation);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.InvestigationRecordResult_InvestigationRecordResult).WithMany().HasForeignKey(c => c.InvestigationRecordResult);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.Lab_Contact).WithMany().HasForeignKey(c => c.Lab);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitInvestigationResult>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<ContactInformation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PurchaseOrderSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PurchaseOrderSuggestion>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PurchaseOrderSuggestion>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<TenantAuthorizationFunctions>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReturnFile>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReturnFile>().HasOne(a => a.GoodsReturnId_GoodsReturn).WithMany().HasForeignKey(c => c.GoodsReturnId);
            modelBuilder.Entity<GoodsReturnFile>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<MedicationDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<AppointmentReminderLog>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<AppointmentReminderLog>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<ReferralOrder>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ReferralOrder>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<ReferralOrder>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ReferralOrder>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductCategory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductCategory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductCategory>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UomValueTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UomValueTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<UomValueTranslation>().HasOne(a => a.UomId_UOM).WithMany().HasForeignKey(c => c.UomId);
            modelBuilder.Entity<UomValueTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UomValueTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlowConfiguration>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<WorkFlowConfiguration>().HasOne(a => a.WorkFlowId_WorkFlow).WithMany().HasForeignKey(c => c.WorkFlowId);
            modelBuilder.Entity<WorkFlowConfiguration>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<WorkFlowConfiguration>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<WorkFlowConfiguration>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Covid19History>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Covid19History>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Covid19History>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Diagnosis>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Diagnosis>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Diagnosis>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Diagnosis>().HasOne(a => a.DiagnosisTemplate_DiagnosisTemplate).WithMany().HasForeignKey(c => c.DiagnosisTemplate);
            modelBuilder.Entity<PatientEnrolledPackageProducts>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientEnrolledPackageProducts>().HasOne(a => a.PatientEnrolledPackageId_PatientEnrolledPackage).WithMany().HasForeignKey(c => c.PatientEnrolledPackageId);
            modelBuilder.Entity<PatientEnrolledPackageProducts>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PatientEnrolledPackageProducts>().HasOne(a => a.PatientEnrolledScheduleId_PatientEnrolledPackageSchedule).WithMany().HasForeignKey(c => c.PatientEnrolledScheduleId);
            modelBuilder.Entity<PatientStatistics>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientStatistics>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientStatistics>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientStatistics>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VoidReason>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VoidReason>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VoidReason>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<NotesShortcut>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<NotesShortcut>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<NotesShortcut>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InputType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InputType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InputType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<OrganizationBankDetail>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductFormulation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductFormulation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductFormulation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PurchaseOrderWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PurchaseOrderWorkflowActivityHistory>().HasOne(a => a.PurchaseOrderId_PurchaseOrder).WithMany().HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<PurchaseOrderWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PurchaseOrderWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ChiefComplaintVector_Test>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ChiefComplaintVector_Test>().HasOne(a => a.ChiefComplaintId_ChiefComplaint).WithMany().HasForeignKey(c => c.ChiefComplaintId);
            modelBuilder.Entity<LoyaltyProgram>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitReferral>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitReferral>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitReferral>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitReferral>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitReferral>().HasOne(a => a.InvoiceLineId_InvoiceLine).WithMany().HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<VisitInvestigationResultParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitInvestigationResultParameter>().HasOne(a => a.VisitInvestigationResult_VisitInvestigationResult).WithMany().HasForeignKey(c => c.VisitInvestigationResult);
            modelBuilder.Entity<VisitInvestigationResultParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitInvestigationResultParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitInvestigationResultParameter>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<NotesShortcutDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<NotesShortcutDeviation>().HasOne(a => a.NotesShortcut_NotesShortcut).WithMany().HasForeignKey(c => c.NotesShortcut);
            modelBuilder.Entity<NotesShortcutDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<NotesShortcutDeviation>().HasOne(a => a.ReplacedNotesShortcut_NotesShortcut).WithMany().HasForeignKey(c => c.ReplacedNotesShortcut);
            modelBuilder.Entity<NotesShortcutDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<NotesShortcutDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<FavouriteGoodsReceiptLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<FavouriteGoodsReceiptLine>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<FavouriteGoodsReceiptLine>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<BatchTypeContext>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<BatchTypeContext>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<BatchTypeContext>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RoleOperation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RoleOperation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleOperation>().HasOne(a => a.Role_Role).WithMany().HasForeignKey(c => c.Role);
            modelBuilder.Entity<RoleOperation>().HasOne(a => a.EntityOperation_EntityOperation).WithMany().HasForeignKey(c => c.EntityOperation);
            modelBuilder.Entity<RoleOperation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<RoleOperation>().HasOne(a => a.RoleEntityId_RoleEntity).WithMany().HasForeignKey(c => c.RoleEntityId);
            modelBuilder.Entity<Covid19HistoryChoiceTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Covid19HistoryChoiceTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Covid19HistoryChoiceTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DataType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DataType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DataType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<LoyaltyProgramRule>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<LoyaltyProgramRule>().HasOne(a => a.LoyaltyProgramId_LoyaltyProgram).WithMany().HasForeignKey(c => c.LoyaltyProgramId);
            modelBuilder.Entity<SmsLog>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugList>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugList>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugList>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductClassification>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductClassification>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ProductClassification>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<MedicationNotesTranslation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<MedicationNotesTranslation>().HasOne(a => a.LanguageId_Language).WithMany().HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<MedicationNotesTranslation>().HasOne(a => a.MedicationNotesId_MedicationNotes).WithMany().HasForeignKey(c => c.MedicationNotesId);
            modelBuilder.Entity<MedicationNotesTranslation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<MedicationNotesTranslation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlowConfigurationTransition>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<WorkFlowConfigurationTransition>().HasOne(a => a.WorkflowConfigurationId_WorkFlowConfiguration).WithMany().HasForeignKey(c => c.WorkflowConfigurationId);
            modelBuilder.Entity<WorkFlowConfigurationTransition>().HasOne(a => a.WorkflowTransitionId_WorkFlowTransitions).WithMany().HasForeignKey(c => c.WorkflowTransitionId);
            modelBuilder.Entity<WorkFlowConfigurationTransition>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<WorkFlowConfigurationTransition>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ComorbidityDeviation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ComorbidityDeviation>().HasOne(a => a.Comorbidity_Comorbidity).WithMany().HasForeignKey(c => c.Comorbidity);
            modelBuilder.Entity<ComorbidityDeviation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<ComorbidityDeviation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ComorbidityDeviation>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ProductPackageItems>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductPackageItems>().HasOne(a => a.ProductPackageId_ProductPackage).WithMany().HasForeignKey(c => c.ProductPackageId);
            modelBuilder.Entity<ProductPackageItems>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductPackageItems>().HasOne(a => a.ProductScheduleId_ProductSchedule).WithMany().HasForeignKey(c => c.ProductScheduleId);
            modelBuilder.Entity<TagsMaster>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TagsMaster>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<TagsMaster>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitExaminationTemplateSection>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitExaminationTemplateSection>().HasOne(a => a.VisitExaminationTemplateId_VisitExaminationTemplate).WithMany().HasForeignKey(c => c.VisitExaminationTemplateId);
            modelBuilder.Entity<PackageLineSubGroupFeature>().HasOne(a => a.PackageLineSubGroup_PackageLineSubGroup).WithMany().HasForeignKey(c => c.PackageLineSubGroup);
            modelBuilder.Entity<PackageLineSubGroupFeature>().HasOne(a => a.FeatureParameterId_ClinicalParameter).WithMany().HasForeignKey(c => c.FeatureParameterId);
            modelBuilder.Entity<VisitMode>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitMode>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitMode>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitVoiceTranscript>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitVoiceTranscript>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<TenantInvoiceLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantInvoiceLine>().HasOne(a => a.Invoice_TenantInvoice).WithMany().HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<TenantInvoiceLine>().HasOne(a => a.PackageId_Package).WithMany().HasForeignKey(c => c.PackageId);
            modelBuilder.Entity<GoodsReceiptSuggestion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<GoodsReceiptSuggestion>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<GoodsReceiptSuggestion>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Counter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Counter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Address>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<BatchInterval>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<BatchInterval>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<BatchInterval>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockAdjustmentWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockAdjustmentWorkflowActivityHistory>().HasOne(a => a.StockAdjustmentId_StockAdjustment).WithMany().HasForeignKey(c => c.StockAdjustmentId);
            modelBuilder.Entity<StockAdjustmentWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<StockAdjustmentWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockAdjustmentWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<LifeStyleChoiceTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<LifeStyleChoiceTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<LifeStyleChoiceTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<OpeningBalance>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<OpeningBalance>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<OpeningBalance>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<OpeningBalance>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<OpeningBalance>().HasOne(a => a.SubLocationId_SubLocation).WithMany().HasForeignKey(c => c.SubLocationId);
            modelBuilder.Entity<Covid19HistoryChoice>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Covid19HistoryChoice>().HasOne(a => a.Covid19History_Covid19History).WithMany().HasForeignKey(c => c.Covid19History);
            modelBuilder.Entity<Covid19HistoryChoice>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Covid19HistoryChoice>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitExaminationTemplateSectionColumn>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitExaminationTemplateSectionColumn>().HasOne(a => a.VisitExaminationTemplateSectionId_VisitExaminationTemplateSection).WithMany().HasForeignKey(c => c.VisitExaminationTemplateSectionId);
            modelBuilder.Entity<VisitReferralNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitReferralNotes>().HasOne(a => a.VisitId_Visit).WithMany().HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitReferralNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitReferralNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PackageLineSubGroupFeatureParameter>().HasOne(a => a.PackageLineSubGroupFeature_PackageLineSubGroupFeature).WithMany().HasForeignKey(c => c.PackageLineSubGroupFeature);
            modelBuilder.Entity<PackageLineSubGroupFeatureParameter>().HasOne(a => a.ClinicalParameter_ClinicalParameter).WithMany().HasForeignKey(c => c.ClinicalParameter);
            modelBuilder.Entity<PackageLineSubGroupFeatureParameter>().HasOne(a => a.ClinicalParameterValue_ClinicalParameterValue).WithMany().HasForeignKey(c => c.ClinicalParameterValue);
            modelBuilder.Entity<PackageLineSubGroupFeatureParameter>().HasOne(a => a.UOM_UOM).WithMany().HasForeignKey(c => c.UOM);
            modelBuilder.Entity<PatientNotes>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientNotes>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientNotes>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientNotes>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugSystemOrganType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugSystemOrganType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugSystemOrganType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UserCredentialLogin>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserCredentialLogin>().HasOne(a => a.User_User).WithMany().HasForeignKey(c => c.User);
            modelBuilder.Entity<UserCredentialLogin>().HasOne(a => a.Credential_Credential).WithMany().HasForeignKey(c => c.Credential);
            modelBuilder.Entity<Entities.AppointmentService>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entities.AppointmentService>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<Entities.AppointmentService>().HasOne(a => a.ServiceId_Product).WithMany().HasForeignKey(c => c.ServiceId);
            modelBuilder.Entity<Occupation>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Occupation>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Occupation>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CalenderSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationRecordResult>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvestigationRecordResult>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvestigationRecordResult>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvestigationRecordResult>().HasOne(a => a.Patient_Patient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<InvestigationRecordResult>().HasOne(a => a.VisitInvestigation_VisitInvestigation).WithMany().HasForeignKey(c => c.VisitInvestigation);
            modelBuilder.Entity<InvestigationRecordResult>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<TenantInvoiceFiles>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantInvoiceFiles>().HasOne(a => a.TenantInvoiceId_TenantInvoice).WithMany().HasForeignKey(c => c.TenantInvoiceId);
            modelBuilder.Entity<PatientComorbidityParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PatientComorbidityParameter>().HasOne(a => a.PatientComorbidity_PatientComorbidity).WithMany().HasForeignKey(c => c.PatientComorbidity);
            modelBuilder.Entity<PatientComorbidityParameter>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PatientComorbidityParameter>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Country>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Country>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Country>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<WorkFlowConfigurationTransitionAuthorization>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<WorkFlowConfigurationTransitionAuthorization>().HasOne(a => a.WorkflowConfigurationTransitionId_WorkFlowConfigurationTransition).WithMany().HasForeignKey(c => c.WorkflowConfigurationTransitionId);
            modelBuilder.Entity<WorkFlowConfigurationTransitionAuthorization>().HasOne(a => a.RoleId_Role).WithMany().HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<EmrGeneralSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EmrGeneralSettings>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<EnrolledProgram>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<EnrolledProgram>().HasOne(a => a.LoyaltyProgramId_LoyaltyProgram).WithMany().HasForeignKey(c => c.LoyaltyProgramId);
            modelBuilder.Entity<PriceListVersionComponent>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PriceListVersionComponent>().HasOne(a => a.PriceListId_PriceList).WithMany().HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListVersionComponent>().HasOne(a => a.LocationId_Location).WithMany().HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PriceListVersionComponent>().HasOne(a => a.ContactId_Contact).WithMany().HasForeignKey(c => c.ContactId);
            modelBuilder.Entity<PriceListVersionComponent>().HasOne(a => a.SupplierId_Contact).WithMany().HasForeignKey(c => c.SupplierId);
            modelBuilder.Entity<PriceListVersionComponent>().HasOne(a => a.PriceListVersionId_PriceListVersion).WithMany().HasForeignKey(c => c.PriceListVersionId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.Invoice_Invoice).WithMany().HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.Product_Product).WithMany().HasForeignKey(c => c.Product);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.ProductBatchId_ProductBatch).WithMany().HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.GSTSettingsId_GstSettings).WithMany().HasForeignKey(c => c.GSTSettingsId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.WriteOffBy_User).WithMany().HasForeignKey(c => c.WriteOffBy);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.OverrideBy_User).WithMany().HasForeignKey(c => c.OverrideBy);
            modelBuilder.Entity<UserRoster>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserRoster>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserRoster>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserRoster>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<StockTransferWorkflowActivityHistory>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<StockTransferWorkflowActivityHistory>().HasOne(a => a.StockTransferId_StockTransfer).WithMany().HasForeignKey(c => c.StockTransferId);
            modelBuilder.Entity<StockTransferWorkflowActivityHistory>().HasOne(a => a.WorkflowStateId_WorkFlowStates).WithMany().HasForeignKey(c => c.WorkflowStateId);
            modelBuilder.Entity<StockTransferWorkflowActivityHistory>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<StockTransferWorkflowActivityHistory>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UOMConversion>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UOMConversion>().HasOne(a => a.FromUnitId_UOM).WithMany().HasForeignKey(c => c.FromUnitId);
            modelBuilder.Entity<UOMConversion>().HasOne(a => a.ToUnitId_UOM).WithMany().HasForeignKey(c => c.ToUnitId);
            modelBuilder.Entity<UOMConversion>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UOMConversion>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Timezone>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Currency>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Currency>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Currency>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<CommunicationProviderSettings>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<CommunicationProviderSettings>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<CommunicationProviderSettings>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<ProductTheraputicClassification>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<ProductTheraputicClassification>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductTheraputicClassification>().HasOne(a => a.DrugSystemOrganTypeId_DrugSystemOrganType).WithMany().HasForeignKey(c => c.DrugSystemOrganTypeId);
            modelBuilder.Entity<TenantSubscriptionLineSubGroup>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<TenantSubscriptionLineSubGroup>().HasOne(a => a.TenantSubscriptionLine_TenantSubscriptionLine).WithMany().HasForeignKey(c => c.TenantSubscriptionLine);
            modelBuilder.Entity<TenantSubscriptionLineSubGroup>().HasOne(a => a.PackageLineSubGroup_PackageLineSubGroup).WithMany().HasForeignKey(c => c.PackageLineSubGroup);
            modelBuilder.Entity<VisitType>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitType>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitType>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.PurchaseOrderId_PurchaseOrder).WithMany().HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.ProductId_Product).WithMany().HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.ProductUomId_ProductUom).WithMany().HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.RequisitionId_Requisition).WithMany().HasForeignKey(c => c.RequisitionId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.RequisitionLineId_RequisitionLine).WithMany().HasForeignKey(c => c.RequisitionLineId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.GoodsReceiptId_GoodsReceipt).WithMany().HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.GoodsReceiptItemId_GoodsReceiptItem).WithMany().HasForeignKey(c => c.GoodsReceiptItemId);
            modelBuilder.Entity<Title>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Title>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Title>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DrugToDrugInteraction>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<DrugToDrugInteraction>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<DrugToDrugInteraction>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<PrescriptionPrintTemplate>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PrescriptionPrintTemplate>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PrescriptionPrintTemplate>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<PrescriptionPrintTemplate>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroupParameter>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroupParameter>().HasOne(a => a.VisitExaminationTemplateSectionGroupId_VisitExaminationTemplateSectionGroup).WithMany().HasForeignKey(c => c.VisitExaminationTemplateSectionGroupId);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroupParameter>().HasOne(a => a.VisitExaminationTemplateSectionColumnId_VisitExaminationTemplateSectionColumn).WithMany().HasForeignKey(c => c.VisitExaminationTemplateSectionColumnId);
            modelBuilder.Entity<VisitExaminationTemplateSectionGroupParameter>().HasOne(a => a.UOM_UOM).WithMany().HasForeignKey(c => c.UOM);
            modelBuilder.Entity<Notification>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Notification>().HasOne(a => a.Appointment_Appointment).WithMany().HasForeignKey(c => c.Appointment);
            modelBuilder.Entity<Notification>().HasOne(a => a.Recipient_User).WithMany().HasForeignKey(c => c.Recipient);
            modelBuilder.Entity<VisitMedication>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<VisitMedication>().HasOne(a => a.Visit_Visit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<VisitMedication>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<VisitMedication>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<VisitMedication>().HasOne(a => a.RefillDurationUomId_UOM).WithMany().HasForeignKey(c => c.RefillDurationUomId);
            modelBuilder.Entity<PackageSubscription>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<PackageSubscription>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<PackageSubscription>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
        }

        /// <summary>
        /// Represents the database set for the DrugSystemTherapeuticClass entity.
        /// </summary>
        public DbSet<DrugSystemTherapeuticClass> DrugSystemTherapeuticClass { get; set; }

        /// <summary>
        /// Represents the database set for the BatchContext entity.
        /// </summary>
        public DbSet<BatchContext> BatchContext { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorDrugSystemTherapeuticClass entity.
        /// </summary>
        public DbSet<DoctorDrugSystemTherapeuticClass> DoctorDrugSystemTherapeuticClass { get; set; }

        /// <summary>
        /// Represents the database set for the IntegrationUser entity.
        /// </summary>
        public DbSet<IntegrationUser> IntegrationUser { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureOrderWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<ProcedureOrderWorkflowActivityHistory> ProcedureOrderWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the CashRegister entity.
        /// </summary>
        public DbSet<CashRegister> CashRegister { get; set; }

        /// <summary>
        /// Represents the database set for the DrugListItems entity.
        /// </summary>
        public DbSet<DrugListItems> DrugListItems { get; set; }

        /// <summary>
        /// Represents the database set for the ProductCustomUOM entity.
        /// </summary>
        public DbSet<ProductCustomUOM> ProductCustomUOM { get; set; }

        /// <summary>
        /// Represents the database set for the Gender entity.
        /// </summary>
        public DbSet<Gender> Gender { get; set; }

        /// <summary>
        /// Represents the database set for the ProductTheraputicSubClassification entity.
        /// </summary>
        public DbSet<ProductTheraputicSubClassification> ProductTheraputicSubClassification { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSubscriptionLineSubGroupFeature entity.
        /// </summary>
        public DbSet<TenantSubscriptionLineSubGroupFeature> TenantSubscriptionLineSubGroupFeature { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationInstructionTranslation entity.
        /// </summary>
        public DbSet<MedicationInstructionTranslation> MedicationInstructionTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the RoleType entity.
        /// </summary>
        public DbSet<RoleType> RoleType { get; set; }

        /// <summary>
        /// Represents the database set for the PatientCommunication entity.
        /// </summary>
        public DbSet<PatientCommunication> PatientCommunication { get; set; }

        /// <summary>
        /// Represents the database set for the RequisitionSuggestion entity.
        /// </summary>
        public DbSet<RequisitionSuggestion> RequisitionSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the VisitActivityHistory entity.
        /// </summary>
        public DbSet<VisitActivityHistory> VisitActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<GoodsReceiptWorkflowActivityHistory> GoodsReceiptWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the UnitCategory entity.
        /// </summary>
        public DbSet<UnitCategory> UnitCategory { get; set; }

        /// <summary>
        /// Represents the database set for the AddressType entity.
        /// </summary>
        public DbSet<AddressType> AddressType { get; set; }

        /// <summary>
        /// Represents the database set for the PaymentMode entity.
        /// </summary>
        public DbSet<PaymentMode> PaymentMode { get; set; }

        /// <summary>
        /// Represents the database set for the StockTransfer entity.
        /// </summary>
        public DbSet<StockTransfer> StockTransfer { get; set; }

        /// <summary>
        /// Represents the database set for the CurrencyConversion entity.
        /// </summary>
        public DbSet<CurrencyConversion> CurrencyConversion { get; set; }

        /// <summary>
        /// Represents the database set for the PrescriptionPrintTemplateComponent entity.
        /// </summary>
        public DbSet<PrescriptionPrintTemplateComponent> PrescriptionPrintTemplateComponent { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptSummary entity.
        /// </summary>
        public DbSet<GoodsReceiptSummary> GoodsReceiptSummary { get; set; }

        /// <summary>
        /// Represents the database set for the PatientTag entity.
        /// </summary>
        public DbSet<PatientTag> PatientTag { get; set; }

        /// <summary>
        /// Represents the database set for the TenantInvoice entity.
        /// </summary>
        public DbSet<TenantInvoice> TenantInvoice { get; set; }

        /// <summary>
        /// Represents the database set for the ExaminationSection entity.
        /// </summary>
        public DbSet<ExaminationSection> ExaminationSection { get; set; }

        /// <summary>
        /// Represents the database set for the DrugToDiagnosisInteraction entity.
        /// </summary>
        public DbSet<DrugToDiagnosisInteraction> DrugToDiagnosisInteraction { get; set; }

        /// <summary>
        /// Represents the database set for the JobItem entity.
        /// </summary>
        public DbSet<JobItem> JobItem { get; set; }

        /// <summary>
        /// Represents the database set for the UnitType entity.
        /// </summary>
        public DbSet<UnitType> UnitType { get; set; }

        /// <summary>
        /// Represents the database set for the CurrencyConversionType entity.
        /// </summary>
        public DbSet<CurrencyConversionType> CurrencyConversionType { get; set; }

        /// <summary>
        /// Represents the database set for the CoverCategoryClinicTypeExclusion entity.
        /// </summary>
        public DbSet<CoverCategoryClinicTypeExclusion> CoverCategoryClinicTypeExclusion { get; set; }

        /// <summary>
        /// Represents the database set for the PatientEnrolledPackageSchedulePayment entity.
        /// </summary>
        public DbSet<PatientEnrolledPackageSchedulePayment> PatientEnrolledPackageSchedulePayment { get; set; }

        /// <summary>
        /// Represents the database set for the FevouriteRequisitionLine entity.
        /// </summary>
        public DbSet<FevouriteRequisitionLine> FevouriteRequisitionLine { get; set; }

        /// <summary>
        /// Represents the database set for the Patient entity.
        /// </summary>
        public DbSet<Patient> Patient { get; set; }

        /// <summary>
        /// Represents the database set for the OrganizationSettings entity.
        /// </summary>
        public DbSet<OrganizationSettings> OrganizationSettings { get; set; }

        /// <summary>
        /// Represents the database set for the EntityFieldVisibility entity.
        /// </summary>
        public DbSet<EntityFieldVisibility> EntityFieldVisibility { get; set; }

        /// <summary>
        /// Represents the database set for the CashRegisterVariance entity.
        /// </summary>
        public DbSet<CashRegisterVariance> CashRegisterVariance { get; set; }

        /// <summary>
        /// Represents the database set for the VisitGuideline entity.
        /// </summary>
        public DbSet<VisitGuideline> VisitGuideline { get; set; }

        /// <summary>
        /// Represents the database set for the DispenseActivityHistory entity.
        /// </summary>
        public DbSet<DispenseActivityHistory> DispenseActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the ReadyRxItem entity.
        /// </summary>
        public DbSet<ReadyRxItem> ReadyRxItem { get; set; }

        /// <summary>
        /// Represents the database set for the PriceList entity.
        /// </summary>
        public DbSet<PriceList> PriceList { get; set; }

        /// <summary>
        /// Represents the database set for the SubReason entity.
        /// </summary>
        public DbSet<SubReason> SubReason { get; set; }

        /// <summary>
        /// Represents the database set for the BatchItemHistory entity.
        /// </summary>
        public DbSet<BatchItemHistory> BatchItemHistory { get; set; }

        /// <summary>
        /// Represents the database set for the VisitCovid19HistoryParameter entity.
        /// </summary>
        public DbSet<VisitCovid19HistoryParameter> VisitCovid19HistoryParameter { get; set; }

        /// <summary>
        /// Represents the database set for the IntegrationUserLoginHistory entity.
        /// </summary>
        public DbSet<IntegrationUserLoginHistory> IntegrationUserLoginHistory { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReturnSummary entity.
        /// </summary>
        public DbSet<GoodsReturnSummary> GoodsReturnSummary { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReturnWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<GoodsReturnWorkflowActivityHistory> GoodsReturnWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the VisitClinicalPrintableNotes entity.
        /// </summary>
        public DbSet<VisitClinicalPrintableNotes> VisitClinicalPrintableNotes { get; set; }

        /// <summary>
        /// Represents the database set for the Appointment entity.
        /// </summary>
        public DbSet<Appointment> Appointment { get; set; }

        /// <summary>
        /// Represents the database set for the JobStatus entity.
        /// </summary>
        public DbSet<JobStatus> JobStatus { get; set; }

        /// <summary>
        /// Represents the database set for the VisitCovid19History entity.
        /// </summary>
        public DbSet<VisitCovid19History> VisitCovid19History { get; set; }

        /// <summary>
        /// Represents the database set for the EnrolledProgramDetails entity.
        /// </summary>
        public DbSet<EnrolledProgramDetails> EnrolledProgramDetails { get; set; }

        /// <summary>
        /// Represents the database set for the CoverCategoryProductCategoryExclusion entity.
        /// </summary>
        public DbSet<CoverCategoryProductCategoryExclusion> CoverCategoryProductCategoryExclusion { get; set; }

        /// <summary>
        /// Represents the database set for the TaskType entity.
        /// </summary>
        public DbSet<TaskType> TaskType { get; set; }

        /// <summary>
        /// Represents the database set for the DrugToAllergyInteraction entity.
        /// </summary>
        public DbSet<DrugToAllergyInteraction> DrugToAllergyInteraction { get; set; }

        /// <summary>
        /// Represents the database set for the PaymentGateway entity.
        /// </summary>
        public DbSet<PaymentGateway> PaymentGateway { get; set; }

        /// <summary>
        /// Represents the database set for the LifeStyleChoice entity.
        /// </summary>
        public DbSet<LifeStyleChoice> LifeStyleChoice { get; set; }

        /// <summary>
        /// Represents the database set for the IntegrationUserCredential entity.
        /// </summary>
        public DbSet<IntegrationUserCredential> IntegrationUserCredential { get; set; }

        /// <summary>
        /// Represents the database set for the JobType entity.
        /// </summary>
        public DbSet<JobType> JobType { get; set; }

        /// <summary>
        /// Represents the database set for the DispenseWorkFlowStep entity.
        /// </summary>
        public DbSet<DispenseWorkFlowStep> DispenseWorkFlowStep { get; set; }

        /// <summary>
        /// Represents the database set for the OpeningBalanceItem entity.
        /// </summary>
        public DbSet<OpeningBalanceItem> OpeningBalanceItem { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaintVector entity.
        /// </summary>
        public DbSet<ChiefComplaintVector> ChiefComplaintVector { get; set; }

        /// <summary>
        /// Represents the database set for the UserNotes entity.
        /// </summary>
        public DbSet<UserNotes> UserNotes { get; set; }

        /// <summary>
        /// Represents the database set for the PregnancyHistory entity.
        /// </summary>
        public DbSet<PregnancyHistory> PregnancyHistory { get; set; }

        /// <summary>
        /// Represents the database set for the CashRegisterHistory entity.
        /// </summary>
        public DbSet<CashRegisterHistory> CashRegisterHistory { get; set; }

        /// <summary>
        /// Represents the database set for the ExaminationTemplate entity.
        /// </summary>
        public DbSet<ExaminationTemplate> ExaminationTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the Medication entity.
        /// </summary>
        public DbSet<Medication> Medication { get; set; }

        /// <summary>
        /// Represents the database set for the PatientHospitalisationHistory entity.
        /// </summary>
        public DbSet<PatientHospitalisationHistory> PatientHospitalisationHistory { get; set; }

        /// <summary>
        /// Represents the database set for the Smoking entity.
        /// </summary>
        public DbSet<Smoking> Smoking { get; set; }

        /// <summary>
        /// Represents the database set for the StockAdjustmentSummary entity.
        /// </summary>
        public DbSet<StockAdjustmentSummary> StockAdjustmentSummary { get; set; }

        /// <summary>
        /// Represents the database set for the VisitMedicationDosage entity.
        /// </summary>
        public DbSet<VisitMedicationDosage> VisitMedicationDosage { get; set; }

        /// <summary>
        /// Represents the database set for the TenantReferrals entity.
        /// </summary>
        public DbSet<TenantReferrals> TenantReferrals { get; set; }

        /// <summary>
        /// Represents the database set for the Visit entity.
        /// </summary>
        public DbSet<Visit> Visit { get; set; }

        /// <summary>
        /// Represents the database set for the GlobalUser entity.
        /// </summary>
        public DbSet<GlobalUser> GlobalUser { get; set; }

        /// <summary>
        /// Represents the database set for the VisitReferralFile entity.
        /// </summary>
        public DbSet<VisitReferralFile> VisitReferralFile { get; set; }

        /// <summary>
        /// Represents the database set for the CashRegisterReason entity.
        /// </summary>
        public DbSet<CashRegisterReason> CashRegisterReason { get; set; }

        /// <summary>
        /// Represents the database set for the StockTakeWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<StockTakeWorkflowActivityHistory> StockTakeWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the ClinicalParameterDeviation entity.
        /// </summary>
        public DbSet<ClinicalParameterDeviation> ClinicalParameterDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSettings entity.
        /// </summary>
        public DbSet<TenantSettings> TenantSettings { get; set; }

        /// <summary>
        /// Represents the database set for the PriceListVersion entity.
        /// </summary>
        public DbSet<PriceListVersion> PriceListVersion { get; set; }

        /// <summary>
        /// Represents the database set for the DiagnosisVector entity.
        /// </summary>
        public DbSet<DiagnosisVector> DiagnosisVector { get; set; }

        /// <summary>
        /// Represents the database set for the DrugToPregnancyInteraction entity.
        /// </summary>
        public DbSet<DrugToPregnancyInteraction> DrugToPregnancyInteraction { get; set; }

        /// <summary>
        /// Represents the database set for the StockTakeItemBatches entity.
        /// </summary>
        public DbSet<StockTakeItemBatches> StockTakeItemBatches { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureTemplate entity.
        /// </summary>
        public DbSet<ProcedureTemplate> ProcedureTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the PatientMedicalHistoryNotes entity.
        /// </summary>
        public DbSet<PatientMedicalHistoryNotes> PatientMedicalHistoryNotes { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisation entity.
        /// </summary>
        public DbSet<SpecialityPersonalisation> SpecialityPersonalisation { get; set; }

        /// <summary>
        /// Represents the database set for the PatientAccountHistory entity.
        /// </summary>
        public DbSet<PatientAccountHistory> PatientAccountHistory { get; set; }

        /// <summary>
        /// Represents the database set for the ProductCategoryRule entity.
        /// </summary>
        public DbSet<ProductCategoryRule> ProductCategoryRule { get; set; }

        /// <summary>
        /// Represents the database set for the ClinicalParameterValue entity.
        /// </summary>
        public DbSet<ClinicalParameterValue> ClinicalParameterValue { get; set; }

        /// <summary>
        /// Represents the database set for the VisitTask entity.
        /// </summary>
        public DbSet<VisitTask> VisitTask { get; set; }

        /// <summary>
        /// Represents the database set for the StockAdjustmentFile entity.
        /// </summary>
        public DbSet<StockAdjustmentFile> StockAdjustmentFile { get; set; }

        /// <summary>
        /// Represents the database set for the AiProcessTemplate entity.
        /// </summary>
        public DbSet<AiProcessTemplate> AiProcessTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorDrugSystemOrganType entity.
        /// </summary>
        public DbSet<DoctorDrugSystemOrganType> DoctorDrugSystemOrganType { get; set; }

        /// <summary>
        /// Represents the database set for the RequisitionFile entity.
        /// </summary>
        public DbSet<RequisitionFile> RequisitionFile { get; set; }

        /// <summary>
        /// Represents the database set for the StockInvoiceSummary entity.
        /// </summary>
        public DbSet<StockInvoiceSummary> StockInvoiceSummary { get; set; }

        /// <summary>
        /// Represents the database set for the Allergy entity.
        /// </summary>
        public DbSet<Allergy> Allergy { get; set; }

        /// <summary>
        /// Represents the database set for the AllergyVector entity.
        /// </summary>
        public DbSet<AllergyVector> AllergyVector { get; set; }

        /// <summary>
        /// Represents the database set for the VisitExaminationTemplate entity.
        /// </summary>
        public DbSet<VisitExaminationTemplate> VisitExaminationTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the StockAdjustment entity.
        /// </summary>
        public DbSet<StockAdjustment> StockAdjustment { get; set; }

        /// <summary>
        /// Represents the database set for the SubLocation entity.
        /// </summary>
        public DbSet<SubLocation> SubLocation { get; set; }

        /// <summary>
        /// Represents the database set for the OrderableComponent entity.
        /// </summary>
        public DbSet<OrderableComponent> OrderableComponent { get; set; }

        /// <summary>
        /// Represents the database set for the StockTakeItem entity.
        /// </summary>
        public DbSet<StockTakeItem> StockTakeItem { get; set; }

        /// <summary>
        /// Represents the database set for the DrugListCountry entity.
        /// </summary>
        public DbSet<DrugListCountry> DrugListCountry { get; set; }

        /// <summary>
        /// Represents the database set for the PatientAllergyParameter entity.
        /// </summary>
        public DbSet<PatientAllergyParameter> PatientAllergyParameter { get; set; }

        /// <summary>
        /// Represents the database set for the DrugInteractionLog entity.
        /// </summary>
        public DbSet<DrugInteractionLog> DrugInteractionLog { get; set; }

        /// <summary>
        /// Represents the database set for the ProductSchedule entity.
        /// </summary>
        public DbSet<ProductSchedule> ProductSchedule { get; set; }

        /// <summary>
        /// Represents the database set for the SubscriptionProduct entity.
        /// </summary>
        public DbSet<SubscriptionProduct> SubscriptionProduct { get; set; }

        /// <summary>
        /// Represents the database set for the Image entity.
        /// </summary>
        public DbSet<Image> Image { get; set; }

        /// <summary>
        /// Represents the database set for the ProductGeneric entity.
        /// </summary>
        public DbSet<ProductGeneric> ProductGeneric { get; set; }

        /// <summary>
        /// Represents the database set for the AiFields entity.
        /// </summary>
        public DbSet<AiFields> AiFields { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationTemplate entity.
        /// </summary>
        public DbSet<InvestigationTemplate> InvestigationTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the PatientProcedure entity.
        /// </summary>
        public DbSet<PatientProcedure> PatientProcedure { get; set; }

        /// <summary>
        /// Represents the database set for the PatientPharmacyQueue entity.
        /// </summary>
        public DbSet<PatientPharmacyQueue> PatientPharmacyQueue { get; set; }

        /// <summary>
        /// Represents the database set for the ClinicalParameterRange entity.
        /// </summary>
        public DbSet<ClinicalParameterRange> ClinicalParameterRange { get; set; }

        /// <summary>
        /// Represents the database set for the ProductCategoryGenderRule entity.
        /// </summary>
        public DbSet<ProductCategoryGenderRule> ProductCategoryGenderRule { get; set; }

        /// <summary>
        /// Represents the database set for the ComorbidityVector entity.
        /// </summary>
        public DbSet<ComorbidityVector> ComorbidityVector { get; set; }

        /// <summary>
        /// Represents the database set for the DefaultFormatForLongDate entity.
        /// </summary>
        public DbSet<DefaultFormatForLongDate> DefaultFormatForLongDate { get; set; }

        /// <summary>
        /// Represents the database set for the VisitCheckList entity.
        /// </summary>
        public DbSet<VisitCheckList> VisitCheckList { get; set; }

        /// <summary>
        /// Represents the database set for the ImageBinary entity.
        /// </summary>
        public DbSet<ImageBinary> ImageBinary { get; set; }

        /// <summary>
        /// Represents the database set for the UserInRole entity.
        /// </summary>
        public DbSet<UserInRole> UserInRole { get; set; }

        /// <summary>
        /// Represents the database set for the StockSummary entity.
        /// </summary>
        public DbSet<StockSummary> StockSummary { get; set; }

        /// <summary>
        /// Represents the database set for the Comorbidity entity.
        /// </summary>
        public DbSet<Comorbidity> Comorbidity { get; set; }

        /// <summary>
        /// Represents the database set for the Requisition entity.
        /// </summary>
        public DbSet<Requisition> Requisition { get; set; }

        /// <summary>
        /// Represents the database set for the SubscriptionPrice entity.
        /// </summary>
        public DbSet<SubscriptionPrice> SubscriptionPrice { get; set; }

        /// <summary>
        /// Represents the database set for the ClinicalParameterValueDeviation entity.
        /// </summary>
        public DbSet<ClinicalParameterValueDeviation> ClinicalParameterValueDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the AiInteraction entity.
        /// </summary>
        public DbSet<AiInteraction> AiInteraction { get; set; }

        /// <summary>
        /// Represents the database set for the DrugListSpeciality entity.
        /// </summary>
        public DbSet<DrugListSpeciality> DrugListSpeciality { get; set; }

        /// <summary>
        /// Represents the database set for the AuthorizationLog entity.
        /// </summary>
        public DbSet<AuthorizationLog> AuthorizationLog { get; set; }

        /// <summary>
        /// Represents the database set for the ImageSetting entity.
        /// </summary>
        public DbSet<ImageSetting> ImageSetting { get; set; }

        /// <summary>
        /// Represents the database set for the GstSettings entity.
        /// </summary>
        public DbSet<GstSettings> GstSettings { get; set; }

        /// <summary>
        /// Represents the database set for the DefaultFormatForLongTime entity.
        /// </summary>
        public DbSet<DefaultFormatForLongTime> DefaultFormatForLongTime { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureOrderLine entity.
        /// </summary>
        public DbSet<ProcedureOrderLine> ProcedureOrderLine { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationModuleTemplates entity.
        /// </summary>
        public DbSet<CommunicationModuleTemplates> CommunicationModuleTemplates { get; set; }

        /// <summary>
        /// Represents the database set for the RoomType entity.
        /// </summary>
        public DbSet<RoomType> RoomType { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationVector entity.
        /// </summary>
        public DbSet<InvestigationVector> InvestigationVector { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaintTemplate entity.
        /// </summary>
        public DbSet<ChiefComplaintTemplate> ChiefComplaintTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the PatientProcedureParameter entity.
        /// </summary>
        public DbSet<PatientProcedureParameter> PatientProcedureParameter { get; set; }

        /// <summary>
        /// Represents the database set for the ProductCategoryPatientCategoryRule entity.
        /// </summary>
        public DbSet<ProductCategoryPatientCategoryRule> ProductCategoryPatientCategoryRule { get; set; }

        /// <summary>
        /// Represents the database set for the VideoSession entity.
        /// </summary>
        public DbSet<VideoSession> VideoSession { get; set; }

        /// <summary>
        /// Represents the database set for the FollowUpReferral entity.
        /// </summary>
        public DbSet<FollowUpReferral> FollowUpReferral { get; set; }

        /// <summary>
        /// Represents the database set for the VisitWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<VisitWorkflowActivityHistory> VisitWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationTemplateParameter entity.
        /// </summary>
        public DbSet<InvestigationTemplateParameter> InvestigationTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaintDeviation entity.
        /// </summary>
        public DbSet<ChiefComplaintDeviation> ChiefComplaintDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the VisitDiagnosisNotes entity.
        /// </summary>
        public DbSet<VisitDiagnosisNotes> VisitDiagnosisNotes { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationDosage entity.
        /// </summary>
        public DbSet<MedicationDosage> MedicationDosage { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSubscriptionAdditionalUser entity.
        /// </summary>
        public DbSet<TenantSubscriptionAdditionalUser> TenantSubscriptionAdditionalUser { get; set; }

        /// <summary>
        /// Represents the database set for the GeneralExamTemplate entity.
        /// </summary>
        public DbSet<GeneralExamTemplate> GeneralExamTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the PatientEnrollmentLink entity.
        /// </summary>
        public DbSet<PatientEnrollmentLink> PatientEnrollmentLink { get; set; }

        /// <summary>
        /// Represents the database set for the DefaultFormatForShortDate entity.
        /// </summary>
        public DbSet<DefaultFormatForShortDate> DefaultFormatForShortDate { get; set; }

        /// <summary>
        /// Represents the database set for the StockTakeInitiated entity.
        /// </summary>
        public DbSet<StockTakeInitiated> StockTakeInitiated { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaint entity.
        /// </summary>
        public DbSet<ChiefComplaint> ChiefComplaint { get; set; }

        /// <summary>
        /// Represents the database set for the DataImport entity.
        /// </summary>
        public DbSet<DataImport> DataImport { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationCountry entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationCountry> SpecialityPersonalisationCountry { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationVector entity.
        /// </summary>
        public DbSet<MedicationVector> MedicationVector { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSubscriptionLineSubGroupFeatureParameter entity.
        /// </summary>
        public DbSet<TenantSubscriptionLineSubGroupFeatureParameter> TenantSubscriptionLineSubGroupFeatureParameter { get; set; }

        /// <summary>
        /// Represents the database set for the TokenManagement entity.
        /// </summary>
        public DbSet<TokenManagement> TokenManagement { get; set; }

        /// <summary>
        /// Represents the database set for the ClinicType entity.
        /// </summary>
        public DbSet<ClinicType> ClinicType { get; set; }

        /// <summary>
        /// Represents the database set for the DefaultFormatForShortTime entity.
        /// </summary>
        public DbSet<DefaultFormatForShortTime> DefaultFormatForShortTime { get; set; }

        /// <summary>
        /// Represents the database set for the ProductPaymentPlan entity.
        /// </summary>
        public DbSet<ProductPaymentPlan> ProductPaymentPlan { get; set; }

        /// <summary>
        /// Represents the database set for the AiProcess entity.
        /// </summary>
        public DbSet<AiProcess> AiProcess { get; set; }

        /// <summary>
        /// Represents the database set for the VisitDiagnosisParameter entity.
        /// </summary>
        public DbSet<VisitDiagnosisParameter> VisitDiagnosisParameter { get; set; }

        /// <summary>
        /// Represents the database set for the CoverCategoryClinicExclusion entity.
        /// </summary>
        public DbSet<CoverCategoryClinicExclusion> CoverCategoryClinicExclusion { get; set; }

        /// <summary>
        /// Represents the database set for the GeneralExam entity.
        /// </summary>
        public DbSet<GeneralExam> GeneralExam { get; set; }

        /// <summary>
        /// Represents the database set for the FollowupResult entity.
        /// </summary>
        public DbSet<FollowupResult> FollowupResult { get; set; }

        /// <summary>
        /// Represents the database set for the RoleEntity entity.
        /// </summary>
        public DbSet<RoleEntity> RoleEntity { get; set; }

        /// <summary>
        /// Represents the database set for the AllergyTemplateParameter entity.
        /// </summary>
        public DbSet<AllergyTemplateParameter> AllergyTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReturn entity.
        /// </summary>
        public DbSet<GoodsReturn> GoodsReturn { get; set; }

        /// <summary>
        /// Represents the database set for the PriceListItem entity.
        /// </summary>
        public DbSet<PriceListItem> PriceListItem { get; set; }

        /// <summary>
        /// Represents the database set for the StockTransferSummary entity.
        /// </summary>
        public DbSet<StockTransferSummary> StockTransferSummary { get; set; }

        /// <summary>
        /// Represents the database set for the DosageForm entity.
        /// </summary>
        public DbSet<DosageForm> DosageForm { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationSpeciality entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationSpeciality> SpecialityPersonalisationSpeciality { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorInvestigationProfileItem entity.
        /// </summary>
        public DbSet<DoctorInvestigationProfileItem> DoctorInvestigationProfileItem { get; set; }

        /// <summary>
        /// Represents the database set for the Location entity.
        /// </summary>
        public DbSet<Location> Location { get; set; }

        /// <summary>
        /// Represents the database set for the PatientEnrollmentTenantSettings entity.
        /// </summary>
        public DbSet<PatientEnrollmentTenantSettings> PatientEnrollmentTenantSettings { get; set; }

        /// <summary>
        /// Represents the database set for the FinanceSettings entity.
        /// </summary>
        public DbSet<FinanceSettings> FinanceSettings { get; set; }

        /// <summary>
        /// Represents the database set for the CoverCategoryProductExclusion entity.
        /// </summary>
        public DbSet<CoverCategoryProductExclusion> CoverCategoryProductExclusion { get; set; }

        /// <summary>
        /// Represents the database set for the VisitTaskResult entity.
        /// </summary>
        public DbSet<VisitTaskResult> VisitTaskResult { get; set; }

        /// <summary>
        /// Represents the database set for the Language entity.
        /// </summary>
        public DbSet<Language> Language { get; set; }

        /// <summary>
        /// Represents the database set for the PrescriptionLanguages entity.
        /// </summary>
        public DbSet<PrescriptionLanguages> PrescriptionLanguages { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureVector entity.
        /// </summary>
        public DbSet<ProcedureVector> ProcedureVector { get; set; }

        /// <summary>
        /// Represents the database set for the VendorGroup entity.
        /// </summary>
        public DbSet<VendorGroup> VendorGroup { get; set; }

        /// <summary>
        /// Represents the database set for the InformationObjects entity.
        /// </summary>
        public DbSet<InformationObjects> InformationObjects { get; set; }

        /// <summary>
        /// Represents the database set for the Product entity.
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Represents the database set for the MedicalCertificateFile entity.
        /// </summary>
        public DbSet<MedicalCertificateFile> MedicalCertificateFile { get; set; }

        /// <summary>
        /// Represents the database set for the DiagnosisDeviation entity.
        /// </summary>
        public DbSet<DiagnosisDeviation> DiagnosisDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the StockTransferFile entity.
        /// </summary>
        public DbSet<StockTransferFile> StockTransferFile { get; set; }

        /// <summary>
        /// Represents the database set for the VisitExaminationTemplateSectionGroup entity.
        /// </summary>
        public DbSet<VisitExaminationTemplateSectionGroup> VisitExaminationTemplateSectionGroup { get; set; }

        /// <summary>
        /// Represents the database set for the PriceListComponent entity.
        /// </summary>
        public DbSet<PriceListComponent> PriceListComponent { get; set; }

        /// <summary>
        /// Represents the database set for the ComorbidityTemplateParameter entity.
        /// </summary>
        public DbSet<ComorbidityTemplateParameter> ComorbidityTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the AiProviderSettings entity.
        /// </summary>
        public DbSet<AiProviderSettings> AiProviderSettings { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationChiefComplaint entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationChiefComplaint> SpecialityPersonalisationChiefComplaint { get; set; }

        /// <summary>
        /// Represents the database set for the StockAdjustmentItem entity.
        /// </summary>
        public DbSet<StockAdjustmentItem> StockAdjustmentItem { get; set; }

        /// <summary>
        /// Represents the database set for the VisitChiefComplaintNotes entity.
        /// </summary>
        public DbSet<VisitChiefComplaintNotes> VisitChiefComplaintNotes { get; set; }

        /// <summary>
        /// Represents the database set for the PatientLifeStyle entity.
        /// </summary>
        public DbSet<PatientLifeStyle> PatientLifeStyle { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationDosageFormat entity.
        /// </summary>
        public DbSet<MedicationDosageFormat> MedicationDosageFormat { get; set; }

        /// <summary>
        /// Represents the database set for the ZohoIntegration entity.
        /// </summary>
        public DbSet<ZohoIntegration> ZohoIntegration { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorDiagnosis entity.
        /// </summary>
        public DbSet<DoctorDiagnosis> DoctorDiagnosis { get; set; }

        /// <summary>
        /// Represents the database set for the ClinicalParameter entity.
        /// </summary>
        public DbSet<ClinicalParameter> ClinicalParameter { get; set; }

        /// <summary>
        /// Represents the database set for the MedicalCertificateOrder entity.
        /// </summary>
        public DbSet<MedicalCertificateOrder> MedicalCertificateOrder { get; set; }

        /// <summary>
        /// Represents the database set for the ShortFrequencyValueTranslation entity.
        /// </summary>
        public DbSet<ShortFrequencyValueTranslation> ShortFrequencyValueTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the Covid19HistoryChoiceTemplateParameter entity.
        /// </summary>
        public DbSet<Covid19HistoryChoiceTemplateParameter> Covid19HistoryChoiceTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationDiagnosis entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationDiagnosis> SpecialityPersonalisationDiagnosis { get; set; }

        /// <summary>
        /// Represents the database set for the PrescriptionFiles entity.
        /// </summary>
        public DbSet<PrescriptionFiles> PrescriptionFiles { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReturnItem entity.
        /// </summary>
        public DbSet<GoodsReturnItem> GoodsReturnItem { get; set; }

        /// <summary>
        /// Represents the database set for the VisitMedicalCertificate entity.
        /// </summary>
        public DbSet<VisitMedicalCertificate> VisitMedicalCertificate { get; set; }

        /// <summary>
        /// Represents the database set for the PatientEnrolledPackage entity.
        /// </summary>
        public DbSet<PatientEnrolledPackage> PatientEnrolledPackage { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationInstructionTranslationDeviation entity.
        /// </summary>
        public DbSet<MedicationInstructionTranslationDeviation> MedicationInstructionTranslationDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the GuideLineDeviation entity.
        /// </summary>
        public DbSet<GuideLineDeviation> GuideLineDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the MobileVerification entity.
        /// </summary>
        public DbSet<MobileVerification> MobileVerification { get; set; }

        /// <summary>
        /// Represents the database set for the SMS entity.
        /// </summary>
        public DbSet<SMS> SMS { get; set; }

        /// <summary>
        /// Represents the database set for the Payment entity.
        /// </summary>
        public DbSet<Payment> Payment { get; set; }

        /// <summary>
        /// Represents the database set for the PatientPatientCategory entity.
        /// </summary>
        public DbSet<PatientPatientCategory> PatientPatientCategory { get; set; }

        /// <summary>
        /// Represents the database set for the RoleOperationScope entity.
        /// </summary>
        public DbSet<RoleOperationScope> RoleOperationScope { get; set; }

        /// <summary>
        /// Represents the database set for the Lab entity.
        /// </summary>
        public DbSet<Lab> Lab { get; set; }

        /// <summary>
        /// Represents the database set for the VisitGeneralExamParameter entity.
        /// </summary>
        public DbSet<VisitGeneralExamParameter> VisitGeneralExamParameter { get; set; }

        /// <summary>
        /// Represents the database set for the Email entity.
        /// </summary>
        public DbSet<Email> Email { get; set; }

        /// <summary>
        /// Represents the database set for the Procedure entity.
        /// </summary>
        public DbSet<Procedure> Procedure { get; set; }

        /// <summary>
        /// Represents the database set for the InformationObjectFields entity.
        /// </summary>
        public DbSet<InformationObjectFields> InformationObjectFields { get; set; }

        /// <summary>
        /// Represents the database set for the SmsGatewayType entity.
        /// </summary>
        public DbSet<SmsGatewayType> SmsGatewayType { get; set; }

        /// <summary>
        /// Represents the database set for the LoginHistory entity.
        /// </summary>
        public DbSet<LoginHistory> LoginHistory { get; set; }

        /// <summary>
        /// Represents the database set for the PatientAllergy entity.
        /// </summary>
        public DbSet<PatientAllergy> PatientAllergy { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationProcedure entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationProcedure> SpecialityPersonalisationProcedure { get; set; }

        /// <summary>
        /// Represents the database set for the InvoiceFiles entity.
        /// </summary>
        public DbSet<InvoiceFiles> InvoiceFiles { get; set; }

        /// <summary>
        /// Represents the database set for the EcCoinRules entity.
        /// </summary>
        public DbSet<EcCoinRules> EcCoinRules { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationProfileItem entity.
        /// </summary>
        public DbSet<InvestigationProfileItem> InvestigationProfileItem { get; set; }

        /// <summary>
        /// Represents the database set for the GeneralExamTemplateParameter entity.
        /// </summary>
        public DbSet<GeneralExamTemplateParameter> GeneralExamTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the Generic entity.
        /// </summary>
        public DbSet<Generic> Generic { get; set; }

        /// <summary>
        /// Represents the database set for the EmailStatus entity.
        /// </summary>
        public DbSet<EmailStatus> EmailStatus { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptItem entity.
        /// </summary>
        public DbSet<GoodsReceiptItem> GoodsReceiptItem { get; set; }

        /// <summary>
        /// Represents the database set for the DiagnosisTemplateParameter entity.
        /// </summary>
        public DbSet<DiagnosisTemplateParameter> DiagnosisTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationDeviation entity.
        /// </summary>
        public DbSet<InvestigationDeviation> InvestigationDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the CountryCode entity.
        /// </summary>
        public DbSet<CountryCode> CountryCode { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationTemplateVariable entity.
        /// </summary>
        public DbSet<CommunicationTemplateVariable> CommunicationTemplateVariable { get; set; }

        /// <summary>
        /// Represents the database set for the ReferredBy entity.
        /// </summary>
        public DbSet<ReferredBy> ReferredBy { get; set; }

        /// <summary>
        /// Represents the database set for the EmailTemplate entity.
        /// </summary>
        public DbSet<EmailTemplate> EmailTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the State entity.
        /// </summary>
        public DbSet<State> State { get; set; }

        /// <summary>
        /// Represents the database set for the LocationStockBalance entity.
        /// </summary>
        public DbSet<LocationStockBalance> LocationStockBalance { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationInvestigation entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationInvestigation> SpecialityPersonalisationInvestigation { get; set; }

        /// <summary>
        /// Represents the database set for the EcCoinBenefit entity.
        /// </summary>
        public DbSet<EcCoinBenefit> EcCoinBenefit { get; set; }

        /// <summary>
        /// Represents the database set for the ChatAssistantSettings entity.
        /// </summary>
        public DbSet<ChatAssistantSettings> ChatAssistantSettings { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationOrderLine entity.
        /// </summary>
        public DbSet<InvestigationOrderLine> InvestigationOrderLine { get; set; }

        /// <summary>
        /// Represents the database set for the InformationObjectsRules entity.
        /// </summary>
        public DbSet<InformationObjectsRules> InformationObjectsRules { get; set; }

        /// <summary>
        /// Represents the database set for the File entity.
        /// </summary>
        public DbSet<Entities.File> File { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorChiefComplaint entity.
        /// </summary>
        public DbSet<DoctorChiefComplaint> DoctorChiefComplaint { get; set; }

        /// <summary>
        /// Represents the database set for the DispenseItem entity.
        /// </summary>
        public DbSet<DispenseItem> DispenseItem { get; set; }

        /// <summary>
        /// Represents the database set for the PatientComorbidity entity.
        /// </summary>
        public DbSet<PatientComorbidity> PatientComorbidity { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationModuleEventRelation entity.
        /// </summary>
        public DbSet<CommunicationModuleEventRelation> CommunicationModuleEventRelation { get; set; }

        /// <summary>
        /// Represents the database set for the StockTransferItem entity.
        /// </summary>
        public DbSet<StockTransferItem> StockTransferItem { get; set; }

        /// <summary>
        /// Represents the database set for the Week entity.
        /// </summary>
        public DbSet<Week> Week { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationShortFrequency entity.
        /// </summary>
        public DbSet<MedicationShortFrequency> MedicationShortFrequency { get; set; }

        /// <summary>
        /// Represents the database set for the PatientPayor entity.
        /// </summary>
        public DbSet<PatientPayor> PatientPayor { get; set; }

        /// <summary>
        /// Represents the database set for the VitalTemplate entity.
        /// </summary>
        public DbSet<VitalTemplate> VitalTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the PriceListVersionItem entity.
        /// </summary>
        public DbSet<PriceListVersionItem> PriceListVersionItem { get; set; }

        /// <summary>
        /// Represents the database set for the ProductBatch entity.
        /// </summary>
        public DbSet<ProductBatch> ProductBatch { get; set; }

        /// <summary>
        /// Represents the database set for the InformationObjectsRuleFields entity.
        /// </summary>
        public DbSet<InformationObjectsRuleFields> InformationObjectsRuleFields { get; set; }

        /// <summary>
        /// Represents the database set for the LifeStyleChoiceTemplateParameter entity.
        /// </summary>
        public DbSet<LifeStyleChoiceTemplateParameter> LifeStyleChoiceTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the RequisitionLine entity.
        /// </summary>
        public DbSet<RequisitionLine> RequisitionLine { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationOrderWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<InvestigationOrderWorkflowActivityHistory> InvestigationOrderWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationNotesTranslationDeviation entity.
        /// </summary>
        public DbSet<MedicationNotesTranslationDeviation> MedicationNotesTranslationDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationMedication entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationMedication> SpecialityPersonalisationMedication { get; set; }

        /// <summary>
        /// Represents the database set for the PatientAllergyParameterValue entity.
        /// </summary>
        public DbSet<PatientAllergyParameterValue> PatientAllergyParameterValue { get; set; }

        /// <summary>
        /// Represents the database set for the Report entity.
        /// </summary>
        public DbSet<Report> Report { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationFields entity.
        /// </summary>
        public DbSet<CommunicationFields> CommunicationFields { get; set; }

        /// <summary>
        /// Represents the database set for the OrganisationStockBalance entity.
        /// </summary>
        public DbSet<OrganisationStockBalance> OrganisationStockBalance { get; set; }

        /// <summary>
        /// Represents the database set for the DayVisit entity.
        /// </summary>
        public DbSet<DayVisit> DayVisit { get; set; }

        /// <summary>
        /// Represents the database set for the EnrolledProgramReward entity.
        /// </summary>
        public DbSet<EnrolledProgramReward> EnrolledProgramReward { get; set; }

        /// <summary>
        /// Represents the database set for the VisitClinicalInternalNotes entity.
        /// </summary>
        public DbSet<VisitClinicalInternalNotes> VisitClinicalInternalNotes { get; set; }

        /// <summary>
        /// Represents the database set for the PackageLine entity.
        /// </summary>
        public DbSet<PackageLine> PackageLine { get; set; }

        /// <summary>
        /// Represents the database set for the GuidelineTranslation entity.
        /// </summary>
        public DbSet<GuidelineTranslation> GuidelineTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the ReferredTo entity.
        /// </summary>
        public DbSet<ReferredTo> ReferredTo { get; set; }

        /// <summary>
        /// Represents the database set for the OrganizationSettingsFile entity.
        /// </summary>
        public DbSet<OrganizationSettingsFile> OrganizationSettingsFile { get; set; }

        /// <summary>
        /// Represents the database set for the VisitTypeLocation entity.
        /// </summary>
        public DbSet<VisitTypeLocation> VisitTypeLocation { get; set; }

        /// <summary>
        /// Represents the database set for the VisitCounter entity.
        /// </summary>
        public DbSet<VisitCounter> VisitCounter { get; set; }

        /// <summary>
        /// Represents the database set for the UserAccessLocation entity.
        /// </summary>
        public DbSet<UserAccessLocation> UserAccessLocation { get; set; }

        /// <summary>
        /// Represents the database set for the GuidelineTranslationDeviation entity.
        /// </summary>
        public DbSet<GuidelineTranslationDeviation> GuidelineTranslationDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the AllergyTemplate entity.
        /// </summary>
        public DbSet<AllergyTemplate> AllergyTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the UomInFormulation entity.
        /// </summary>
        public DbSet<UomInFormulation> UomInFormulation { get; set; }

        /// <summary>
        /// Represents the database set for the DependentInformationObjects entity.
        /// </summary>
        public DbSet<DependentInformationObjects> DependentInformationObjects { get; set; }

        /// <summary>
        /// Represents the database set for the Entity entity.
        /// </summary>
        public DbSet<Entity> Entity { get; set; }

        /// <summary>
        /// Represents the database set for the AppointmentCounter entity.
        /// </summary>
        public DbSet<AppointmentCounter> AppointmentCounter { get; set; }

        /// <summary>
        /// Represents the database set for the UserBankDetails entity.
        /// </summary>
        public DbSet<UserBankDetails> UserBankDetails { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationExaminationTemplate entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationExaminationTemplate> SpecialityPersonalisationExaminationTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the DrugSchedule entity.
        /// </summary>
        public DbSet<DrugSchedule> DrugSchedule { get; set; }

        /// <summary>
        /// Represents the database set for the CredentialHistory entity.
        /// </summary>
        public DbSet<CredentialHistory> CredentialHistory { get; set; }

        /// <summary>
        /// Represents the database set for the DispenseItemDosage entity.
        /// </summary>
        public DbSet<DispenseItemDosage> DispenseItemDosage { get; set; }

        /// <summary>
        /// Represents the database set for the VisitTypeCheckList entity.
        /// </summary>
        public DbSet<VisitTypeCheckList> VisitTypeCheckList { get; set; }

        /// <summary>
        /// Represents the database set for the UserCounter entity.
        /// </summary>
        public DbSet<UserCounter> UserCounter { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorFavouriteMedication entity.
        /// </summary>
        public DbSet<DoctorFavouriteMedication> DoctorFavouriteMedication { get; set; }

        /// <summary>
        /// Represents the database set for the TenantCulture entity.
        /// </summary>
        public DbSet<TenantCulture> TenantCulture { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureTemplateParameter entity.
        /// </summary>
        public DbSet<ProcedureTemplateParameter> ProcedureTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationMeter entity.
        /// </summary>
        public DbSet<CommunicationMeter> CommunicationMeter { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaintSuggestion entity.
        /// </summary>
        public DbSet<ChiefComplaintSuggestion> ChiefComplaintSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the VisitInvestigation entity.
        /// </summary>
        public DbSet<VisitInvestigation> VisitInvestigation { get; set; }

        /// <summary>
        /// Represents the database set for the InformationObjectVersions entity.
        /// </summary>
        public DbSet<InformationObjectVersions> InformationObjectVersions { get; set; }

        /// <summary>
        /// Represents the database set for the UOM entity.
        /// </summary>
        public DbSet<UOM> UOM { get; set; }

        /// <summary>
        /// Represents the database set for the PatientCounter entity.
        /// </summary>
        public DbSet<PatientCounter> PatientCounter { get; set; }

        /// <summary>
        /// Represents the database set for the PatientPregnancy entity.
        /// </summary>
        public DbSet<PatientPregnancy> PatientPregnancy { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationComorbidity entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationComorbidity> SpecialityPersonalisationComorbidity { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceipt entity.
        /// </summary>
        public DbSet<GoodsReceipt> GoodsReceipt { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorReport entity.
        /// </summary>
        public DbSet<DoctorReport> DoctorReport { get; set; }

        /// <summary>
        /// Represents the database set for the PurchaseOrderCounter entity.
        /// </summary>
        public DbSet<PurchaseOrderCounter> PurchaseOrderCounter { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationTemplate entity.
        /// </summary>
        public DbSet<CommunicationTemplate> CommunicationTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the Route entity.
        /// </summary>
        public DbSet<Entities.Route> Route { get; set; }

        /// <summary>
        /// Represents the database set for the UserHoliday entity.
        /// </summary>
        public DbSet<UserHoliday> UserHoliday { get; set; }

        /// <summary>
        /// Represents the database set for the InformationObjectFieldSettings entity.
        /// </summary>
        public DbSet<InformationObjectFieldSettings> InformationObjectFieldSettings { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSubscription entity.
        /// </summary>
        public DbSet<TenantSubscription> TenantSubscription { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptCounter entity.
        /// </summary>
        public DbSet<GoodsReceiptCounter> GoodsReceiptCounter { get; set; }

        /// <summary>
        /// Represents the database set for the AgeUnit entity.
        /// </summary>
        public DbSet<AgeUnit> AgeUnit { get; set; }

        /// <summary>
        /// Represents the database set for the DispenseFile entity.
        /// </summary>
        public DbSet<DispenseFile> DispenseFile { get; set; }

        /// <summary>
        /// Represents the database set for the DiagnosisSuggestion entity.
        /// </summary>
        public DbSet<DiagnosisSuggestion> DiagnosisSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationAllergy entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationAllergy> SpecialityPersonalisationAllergy { get; set; }

        /// <summary>
        /// Represents the database set for the VisitVitalParameter entity.
        /// </summary>
        public DbSet<VisitVitalParameter> VisitVitalParameter { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReturnCounter entity.
        /// </summary>
        public DbSet<GoodsReturnCounter> GoodsReturnCounter { get; set; }

        /// <summary>
        /// Represents the database set for the SubscriptionCategory entity.
        /// </summary>
        public DbSet<SubscriptionCategory> SubscriptionCategory { get; set; }

        /// <summary>
        /// Represents the database set for the FileBinary entity.
        /// </summary>
        public DbSet<FileBinary> FileBinary { get; set; }

        /// <summary>
        /// Represents the database set for the ReferralOrderLine entity.
        /// </summary>
        public DbSet<ReferralOrderLine> ReferralOrderLine { get; set; }

        /// <summary>
        /// Represents the database set for the VitalTemplateParameter entity.
        /// </summary>
        public DbSet<VitalTemplateParameter> VitalTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the InventorySettings entity.
        /// </summary>
        public DbSet<InventorySettings> InventorySettings { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationNotes entity.
        /// </summary>
        public DbSet<MedicationNotes> MedicationNotes { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationSuggestion entity.
        /// </summary>
        public DbSet<InvestigationSuggestion> InvestigationSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the PatientCategory entity.
        /// </summary>
        public DbSet<PatientCategory> PatientCategory { get; set; }

        /// <summary>
        /// Represents the database set for the City entity.
        /// </summary>
        public DbSet<City> City { get; set; }

        /// <summary>
        /// Represents the database set for the PurchaseOrder entity.
        /// </summary>
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        /// <summary>
        /// Represents the database set for the RequisitionCounter entity.
        /// </summary>
        public DbSet<RequisitionCounter> RequisitionCounter { get; set; }

        /// <summary>
        /// Represents the database set for the Investigation entity.
        /// </summary>
        public DbSet<Investigation> Investigation { get; set; }

        /// <summary>
        /// Represents the database set for the CoverCategory entity.
        /// </summary>
        public DbSet<CoverCategory> CoverCategory { get; set; }

        /// <summary>
        /// Represents the database set for the PatientLifeStyleParameter entity.
        /// </summary>
        public DbSet<PatientLifeStyleParameter> PatientLifeStyleParameter { get; set; }

        /// <summary>
        /// Represents the database set for the User entity.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Represents the database set for the ExaminationSectionGroup entity.
        /// </summary>
        public DbSet<ExaminationSectionGroup> ExaminationSectionGroup { get; set; }

        /// <summary>
        /// Represents the database set for the Dispense entity.
        /// </summary>
        public DbSet<Dispense> Dispense { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationSuggestion entity.
        /// </summary>
        public DbSet<MedicationSuggestion> MedicationSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSubscriptionLine entity.
        /// </summary>
        public DbSet<TenantSubscriptionLine> TenantSubscriptionLine { get; set; }

        /// <summary>
        /// Represents the database set for the VisitInvestigationRecurrence entity.
        /// </summary>
        public DbSet<VisitInvestigationRecurrence> VisitInvestigationRecurrence { get; set; }

        /// <summary>
        /// Represents the database set for the StockTransferCounter entity.
        /// </summary>
        public DbSet<StockTransferCounter> StockTransferCounter { get; set; }

        /// <summary>
        /// Represents the database set for the sysdiagrams entity.
        /// </summary>
        public DbSet<sysdiagrams> sysdiagrams { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationComponent entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationComponent> SpecialityPersonalisationComponent { get; set; }

        /// <summary>
        /// Represents the database set for the FrequencyValue entity.
        /// </summary>
        public DbSet<FrequencyValue> FrequencyValue { get; set; }

        /// <summary>
        /// Represents the database set for the GuidelineSuggestion entity.
        /// </summary>
        public DbSet<GuidelineSuggestion> GuidelineSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the TenantInvoicePayment entity.
        /// </summary>
        public DbSet<TenantInvoicePayment> TenantInvoicePayment { get; set; }

        /// <summary>
        /// Represents the database set for the AiMeter entity.
        /// </summary>
        public DbSet<AiMeter> AiMeter { get; set; }

        /// <summary>
        /// Represents the database set for the StockTakeCounter entity.
        /// </summary>
        public DbSet<StockTakeCounter> StockTakeCounter { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationModuleEventTemplateRelation entity.
        /// </summary>
        public DbSet<CommunicationModuleEventTemplateRelation> CommunicationModuleEventTemplateRelation { get; set; }

        /// <summary>
        /// Represents the database set for the ContactMember entity.
        /// </summary>
        public DbSet<ContactMember> ContactMember { get; set; }

        /// <summary>
        /// Represents the database set for the FileSetting entity.
        /// </summary>
        public DbSet<FileSetting> FileSetting { get; set; }

        /// <summary>
        /// Represents the database set for the GuidelineGroupItem entity.
        /// </summary>
        public DbSet<GuidelineGroupItem> GuidelineGroupItem { get; set; }

        /// <summary>
        /// Represents the database set for the ReportDeviation entity.
        /// </summary>
        public DbSet<ReportDeviation> ReportDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the InvoiceTaxBreakup entity.
        /// </summary>
        public DbSet<InvoiceTaxBreakup> InvoiceTaxBreakup { get; set; }

        /// <summary>
        /// Represents the database set for the StockTake entity.
        /// </summary>
        public DbSet<StockTake> StockTake { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationVerification entity.
        /// </summary>
        public DbSet<CommunicationVerification> CommunicationVerification { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaintTemplateParameter entity.
        /// </summary>
        public DbSet<ChiefComplaintTemplateParameter> ChiefComplaintTemplateParameter { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorComorbidity entity.
        /// </summary>
        public DbSet<DoctorComorbidity> DoctorComorbidity { get; set; }

        /// <summary>
        /// Represents the database set for the TemplateComponentParameters entity.
        /// </summary>
        public DbSet<TemplateComponentParameters> TemplateComponentParameters { get; set; }

        /// <summary>
        /// Represents the database set for the ProductRule entity.
        /// </summary>
        public DbSet<ProductRule> ProductRule { get; set; }

        /// <summary>
        /// Represents the database set for the ProducedType entity.
        /// </summary>
        public DbSet<ProducedType> ProducedType { get; set; }

        /// <summary>
        /// Represents the database set for the StockAdjustmentCounter entity.
        /// </summary>
        public DbSet<StockAdjustmentCounter> StockAdjustmentCounter { get; set; }

        /// <summary>
        /// Represents the database set for the EntityVectorConfiguration entity.
        /// </summary>
        public DbSet<EntityVectorConfiguration> EntityVectorConfiguration { get; set; }

        /// <summary>
        /// Represents the database set for the ExaminationSectionGroupParameter entity.
        /// </summary>
        public DbSet<ExaminationSectionGroupParameter> ExaminationSectionGroupParameter { get; set; }

        /// <summary>
        /// Represents the database set for the SpecialityPersonalisationDruglist entity.
        /// </summary>
        public DbSet<SpecialityPersonalisationDruglist> SpecialityPersonalisationDruglist { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationInstruction entity.
        /// </summary>
        public DbSet<MedicationInstruction> MedicationInstruction { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureOrder entity.
        /// </summary>
        public DbSet<ProcedureOrder> ProcedureOrder { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationOrderCounter entity.
        /// </summary>
        public DbSet<InvestigationOrderCounter> InvestigationOrderCounter { get; set; }

        /// <summary>
        /// Represents the database set for the ReferralOrderCounter entity.
        /// </summary>
        public DbSet<ReferralOrderCounter> ReferralOrderCounter { get; set; }

        /// <summary>
        /// Represents the database set for the IntegrationUserToken entity.
        /// </summary>
        public DbSet<IntegrationUserToken> IntegrationUserToken { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorInvestigation entity.
        /// </summary>
        public DbSet<DoctorInvestigation> DoctorInvestigation { get; set; }

        /// <summary>
        /// Represents the database set for the VisitChiefComplaintParameter entity.
        /// </summary>
        public DbSet<VisitChiefComplaintParameter> VisitChiefComplaintParameter { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationOrder entity.
        /// </summary>
        public DbSet<InvestigationOrder> InvestigationOrder { get; set; }

        /// <summary>
        /// Represents the database set for the ReportAccess entity.
        /// </summary>
        public DbSet<ReportAccess> ReportAccess { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorAllergy entity.
        /// </summary>
        public DbSet<DoctorAllergy> DoctorAllergy { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationEventTemplates entity.
        /// </summary>
        public DbSet<CommunicationEventTemplates> CommunicationEventTemplates { get; set; }

        /// <summary>
        /// Represents the database set for the Formulation entity.
        /// </summary>
        public DbSet<Formulation> Formulation { get; set; }

        /// <summary>
        /// Represents the database set for the VisitInvestigationNotes entity.
        /// </summary>
        public DbSet<VisitInvestigationNotes> VisitInvestigationNotes { get; set; }

        /// <summary>
        /// Represents the database set for the ExaminationTemplateSection entity.
        /// </summary>
        public DbSet<ExaminationTemplateSection> ExaminationTemplateSection { get; set; }

        /// <summary>
        /// Represents the database set for the EntityOperation entity.
        /// </summary>
        public DbSet<EntityOperation> EntityOperation { get; set; }

        /// <summary>
        /// Represents the database set for the WorkFlow entity.
        /// </summary>
        public DbSet<WorkFlow> WorkFlow { get; set; }

        /// <summary>
        /// Represents the database set for the MedicalCertificateOrderCounter entity.
        /// </summary>
        public DbSet<MedicalCertificateOrderCounter> MedicalCertificateOrderCounter { get; set; }

        /// <summary>
        /// Represents the database set for the Guideline entity.
        /// </summary>
        public DbSet<Guideline> Guideline { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationContextType entity.
        /// </summary>
        public DbSet<CommunicationContextType> CommunicationContextType { get; set; }

        /// <summary>
        /// Represents the database set for the DoctorProcedure entity.
        /// </summary>
        public DbSet<DoctorProcedure> DoctorProcedure { get; set; }

        /// <summary>
        /// Represents the database set for the ProductGenderRule entity.
        /// </summary>
        public DbSet<ProductGenderRule> ProductGenderRule { get; set; }

        /// <summary>
        /// Represents the database set for the PrescriptionFooter entity.
        /// </summary>
        public DbSet<PrescriptionFooter> PrescriptionFooter { get; set; }

        /// <summary>
        /// Represents the database set for the Membership entity.
        /// </summary>
        public DbSet<Membership> Membership { get; set; }

        /// <summary>
        /// Represents the database set for the EMRSuggestionLog entity.
        /// </summary>
        public DbSet<EMRSuggestionLog> EMRSuggestionLog { get; set; }

        /// <summary>
        /// Represents the database set for the UserGoogleAuthorization entity.
        /// </summary>
        public DbSet<UserGoogleAuthorization> UserGoogleAuthorization { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureOrderCounter entity.
        /// </summary>
        public DbSet<ProcedureOrderCounter> ProcedureOrderCounter { get; set; }

        /// <summary>
        /// Represents the database set for the ThirdPartyIntegration entity.
        /// </summary>
        public DbSet<ThirdPartyIntegration> ThirdPartyIntegration { get; set; }

        /// <summary>
        /// Represents the database set for the EmrTemplate entity.
        /// </summary>
        public DbSet<EmrTemplate> EmrTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the Package entity.
        /// </summary>
        public DbSet<Package> Package { get; set; }

        /// <summary>
        /// Represents the database set for the Speciality entity.
        /// </summary>
        public DbSet<Speciality> Speciality { get; set; }

        /// <summary>
        /// Represents the database set for the Tenant entity.
        /// </summary>
        public DbSet<Tenant> Tenant { get; set; }

        /// <summary>
        /// Represents the database set for the TenantDeleteOtp entity.
        /// </summary>
        public DbSet<TenantDeleteOtp> TenantDeleteOtp { get; set; }

        /// <summary>
        /// Represents the database set for the ProductUom entity.
        /// </summary>
        public DbSet<ProductUom> ProductUom { get; set; }

        /// <summary>
        /// Represents the database set for the InvoiceCounter entity.
        /// </summary>
        public DbSet<InvoiceCounter> InvoiceCounter { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationLog entity.
        /// </summary>
        public DbSet<CommunicationLog> CommunicationLog { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptPurchaseOrderRelation entity.
        /// </summary>
        public DbSet<GoodsReceiptPurchaseOrderRelation> GoodsReceiptPurchaseOrderRelation { get; set; }

        /// <summary>
        /// Represents the database set for the AccountSettlement entity.
        /// </summary>
        public DbSet<AccountSettlement> AccountSettlement { get; set; }

        /// <summary>
        /// Represents the database set for the VisitChiefComplaint entity.
        /// </summary>
        public DbSet<VisitChiefComplaint> VisitChiefComplaint { get; set; }

        /// <summary>
        /// Represents the database set for the VisitWorkFlowStep entity.
        /// </summary>
        public DbSet<VisitWorkFlowStep> VisitWorkFlowStep { get; set; }

        /// <summary>
        /// Represents the database set for the Contact entity.
        /// </summary>
        public DbSet<Contact> Contact { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationMode entity.
        /// </summary>
        public DbSet<CommunicationMode> CommunicationMode { get; set; }

        /// <summary>
        /// Represents the database set for the ProductPackage entity.
        /// </summary>
        public DbSet<ProductPackage> ProductPackage { get; set; }

        /// <summary>
        /// Represents the database set for the ProductPatientCategoryRule entity.
        /// </summary>
        public DbSet<ProductPatientCategoryRule> ProductPatientCategoryRule { get; set; }

        /// <summary>
        /// Represents the database set for the CreditInvoiceCounter entity.
        /// </summary>
        public DbSet<CreditInvoiceCounter> CreditInvoiceCounter { get; set; }

        /// <summary>
        /// Represents the database set for the IcdCode entity.
        /// </summary>
        public DbSet<IcdCode> IcdCode { get; set; }

        /// <summary>
        /// Represents the database set for the FrequencyValueTranslation entity.
        /// </summary>
        public DbSet<FrequencyValueTranslation> FrequencyValueTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the Qualification entity.
        /// </summary>
        public DbSet<Qualification> Qualification { get; set; }

        /// <summary>
        /// Represents the database set for the VisitGeneralExam entity.
        /// </summary>
        public DbSet<VisitGeneralExam> VisitGeneralExam { get; set; }

        /// <summary>
        /// Represents the database set for the WorkFlowStates entity.
        /// </summary>
        public DbSet<WorkFlowStates> WorkFlowStates { get; set; }

        /// <summary>
        /// Represents the database set for the AllergyDeviation entity.
        /// </summary>
        public DbSet<AllergyDeviation> AllergyDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the TemplateComponents entity.
        /// </summary>
        public DbSet<TemplateComponents> TemplateComponents { get; set; }

        /// <summary>
        /// Represents the database set for the VisitDiagnosis entity.
        /// </summary>
        public DbSet<VisitDiagnosis> VisitDiagnosis { get; set; }

        /// <summary>
        /// Represents the database set for the PurchaseOrderFile entity.
        /// </summary>
        public DbSet<PurchaseOrderFile> PurchaseOrderFile { get; set; }

        /// <summary>
        /// Represents the database set for the PaymentCounter entity.
        /// </summary>
        public DbSet<PaymentCounter> PaymentCounter { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationComposition entity.
        /// </summary>
        public DbSet<MedicationComposition> MedicationComposition { get; set; }

        /// <summary>
        /// Represents the database set for the DespenceCounter entity.
        /// </summary>
        public DbSet<DespenceCounter> DespenceCounter { get; set; }

        /// <summary>
        /// Represents the database set for the CoverCategorySubscription entity.
        /// </summary>
        public DbSet<CoverCategorySubscription> CoverCategorySubscription { get; set; }

        /// <summary>
        /// Represents the database set for the ProductLocationPrice entity.
        /// </summary>
        public DbSet<ProductLocationPrice> ProductLocationPrice { get; set; }

        /// <summary>
        /// Represents the database set for the Lifestyle entity.
        /// </summary>
        public DbSet<Lifestyle> Lifestyle { get; set; }

        /// <summary>
        /// Represents the database set for the ContactProductCategory entity.
        /// </summary>
        public DbSet<ContactProductCategory> ContactProductCategory { get; set; }

        /// <summary>
        /// Represents the database set for the Invoice entity.
        /// </summary>
        public DbSet<Invoice> Invoice { get; set; }

        /// <summary>
        /// Represents the database set for the StockTakeFile entity.
        /// </summary>
        public DbSet<StockTakeFile> StockTakeFile { get; set; }

        /// <summary>
        /// Represents the database set for the DiagnosisTemplate entity.
        /// </summary>
        public DbSet<DiagnosisTemplate> DiagnosisTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the PackageLineSubGroup entity.
        /// </summary>
        public DbSet<PackageLineSubGroup> PackageLineSubGroup { get; set; }

        /// <summary>
        /// Represents the database set for the NationalIdType entity.
        /// </summary>
        public DbSet<NationalIdType> NationalIdType { get; set; }

        /// <summary>
        /// Represents the database set for the FavouritePurchaseOrderLine entity.
        /// </summary>
        public DbSet<FavouritePurchaseOrderLine> FavouritePurchaseOrderLine { get; set; }

        /// <summary>
        /// Represents the database set for the Settings entity.
        /// </summary>
        public DbSet<Settings> Settings { get; set; }

        /// <summary>
        /// Represents the database set for the PatientAutoAppointmentLink entity.
        /// </summary>
        public DbSet<PatientAutoAppointmentLink> PatientAutoAppointmentLink { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptFile entity.
        /// </summary>
        public DbSet<GoodsReceiptFile> GoodsReceiptFile { get; set; }

        /// <summary>
        /// Represents the database set for the PatientEnrolledPackageSchedule entity.
        /// </summary>
        public DbSet<PatientEnrolledPackageSchedule> PatientEnrolledPackageSchedule { get; set; }

        /// <summary>
        /// Represents the database set for the OtherMedicationTranslation entity.
        /// </summary>
        public DbSet<OtherMedicationTranslation> OtherMedicationTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureDeviation entity.
        /// </summary>
        public DbSet<ProcedureDeviation> ProcedureDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the EntityFieldAuthorization entity.
        /// </summary>
        public DbSet<EntityFieldAuthorization> EntityFieldAuthorization { get; set; }

        /// <summary>
        /// Represents the database set for the RequisitionWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<RequisitionWorkflowActivityHistory> RequisitionWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the ProductManufacture entity.
        /// </summary>
        public DbSet<ProductManufacture> ProductManufacture { get; set; }

        /// <summary>
        /// Represents the database set for the ComorbidityTemplate entity.
        /// </summary>
        public DbSet<ComorbidityTemplate> ComorbidityTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the Role entity.
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// Represents the database set for the WorkFlowTransitions entity.
        /// </summary>
        public DbSet<WorkFlowTransitions> WorkFlowTransitions { get; set; }

        /// <summary>
        /// Represents the database set for the TenantExtension entity.
        /// </summary>
        public DbSet<TenantExtension> TenantExtension { get; set; }

        /// <summary>
        /// Represents the database set for the UserDrugList entity.
        /// </summary>
        public DbSet<UserDrugList> UserDrugList { get; set; }

        /// <summary>
        /// Represents the database set for the VisitMedicationRefill entity.
        /// </summary>
        public DbSet<VisitMedicationRefill> VisitMedicationRefill { get; set; }

        /// <summary>
        /// Represents the database set for the VisitInvestigationResult entity.
        /// </summary>
        public DbSet<VisitInvestigationResult> VisitInvestigationResult { get; set; }

        /// <summary>
        /// Represents the database set for the ContactInformation entity.
        /// </summary>
        public DbSet<ContactInformation> ContactInformation { get; set; }

        /// <summary>
        /// Represents the database set for the PurchaseOrderSuggestion entity.
        /// </summary>
        public DbSet<PurchaseOrderSuggestion> PurchaseOrderSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the TenantAuthorizationFunctions entity.
        /// </summary>
        public DbSet<TenantAuthorizationFunctions> TenantAuthorizationFunctions { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReturnFile entity.
        /// </summary>
        public DbSet<GoodsReturnFile> GoodsReturnFile { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationDeviation entity.
        /// </summary>
        public DbSet<MedicationDeviation> MedicationDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the AppointmentReminderLog entity.
        /// </summary>
        public DbSet<AppointmentReminderLog> AppointmentReminderLog { get; set; }

        /// <summary>
        /// Represents the database set for the ReferralOrder entity.
        /// </summary>
        public DbSet<ReferralOrder> ReferralOrder { get; set; }

        /// <summary>
        /// Represents the database set for the ProductCategory entity.
        /// </summary>
        public DbSet<ProductCategory> ProductCategory { get; set; }

        /// <summary>
        /// Represents the database set for the UomValueTranslation entity.
        /// </summary>
        public DbSet<UomValueTranslation> UomValueTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the WorkFlowConfiguration entity.
        /// </summary>
        public DbSet<WorkFlowConfiguration> WorkFlowConfiguration { get; set; }

        /// <summary>
        /// Represents the database set for the Covid19History entity.
        /// </summary>
        public DbSet<Covid19History> Covid19History { get; set; }

        /// <summary>
        /// Represents the database set for the Diagnosis entity.
        /// </summary>
        public DbSet<Diagnosis> Diagnosis { get; set; }

        /// <summary>
        /// Represents the database set for the PatientEnrolledPackageProducts entity.
        /// </summary>
        public DbSet<PatientEnrolledPackageProducts> PatientEnrolledPackageProducts { get; set; }

        /// <summary>
        /// Represents the database set for the PatientStatistics entity.
        /// </summary>
        public DbSet<PatientStatistics> PatientStatistics { get; set; }

        /// <summary>
        /// Represents the database set for the VoidReason entity.
        /// </summary>
        public DbSet<VoidReason> VoidReason { get; set; }

        /// <summary>
        /// Represents the database set for the NotesShortcut entity.
        /// </summary>
        public DbSet<NotesShortcut> NotesShortcut { get; set; }

        /// <summary>
        /// Represents the database set for the InputType entity.
        /// </summary>
        public DbSet<InputType> InputType { get; set; }

        /// <summary>
        /// Represents the database set for the OrganizationBankDetail entity.
        /// </summary>
        public DbSet<OrganizationBankDetail> OrganizationBankDetail { get; set; }

        /// <summary>
        /// Represents the database set for the ProductFormulation entity.
        /// </summary>
        public DbSet<ProductFormulation> ProductFormulation { get; set; }

        /// <summary>
        /// Represents the database set for the PurchaseOrderWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<PurchaseOrderWorkflowActivityHistory> PurchaseOrderWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the ChiefComplaintVector_Test entity.
        /// </summary>
        public DbSet<ChiefComplaintVector_Test> ChiefComplaintVector_Test { get; set; }

        /// <summary>
        /// Represents the database set for the LoyaltyProgram entity.
        /// </summary>
        public DbSet<LoyaltyProgram> LoyaltyProgram { get; set; }

        /// <summary>
        /// Represents the database set for the VisitReferral entity.
        /// </summary>
        public DbSet<VisitReferral> VisitReferral { get; set; }

        /// <summary>
        /// Represents the database set for the VisitInvestigationResultParameter entity.
        /// </summary>
        public DbSet<VisitInvestigationResultParameter> VisitInvestigationResultParameter { get; set; }

        /// <summary>
        /// Represents the database set for the NotesShortcutDeviation entity.
        /// </summary>
        public DbSet<NotesShortcutDeviation> NotesShortcutDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the FavouriteGoodsReceiptLine entity.
        /// </summary>
        public DbSet<FavouriteGoodsReceiptLine> FavouriteGoodsReceiptLine { get; set; }

        /// <summary>
        /// Represents the database set for the BatchTypeContext entity.
        /// </summary>
        public DbSet<BatchTypeContext> BatchTypeContext { get; set; }

        /// <summary>
        /// Represents the database set for the RoleOperation entity.
        /// </summary>
        public DbSet<RoleOperation> RoleOperation { get; set; }

        /// <summary>
        /// Represents the database set for the Covid19HistoryChoiceTemplate entity.
        /// </summary>
        public DbSet<Covid19HistoryChoiceTemplate> Covid19HistoryChoiceTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the DataType entity.
        /// </summary>
        public DbSet<DataType> DataType { get; set; }

        /// <summary>
        /// Represents the database set for the LoyaltyProgramRule entity.
        /// </summary>
        public DbSet<LoyaltyProgramRule> LoyaltyProgramRule { get; set; }

        /// <summary>
        /// Represents the database set for the SmsLog entity.
        /// </summary>
        public DbSet<SmsLog> SmsLog { get; set; }

        /// <summary>
        /// Represents the database set for the Active entity.
        /// </summary>
        public DbSet<Active> Active { get; set; }

        /// <summary>
        /// Represents the database set for the DrugList entity.
        /// </summary>
        public DbSet<DrugList> DrugList { get; set; }

        /// <summary>
        /// Represents the database set for the ProductClassification entity.
        /// </summary>
        public DbSet<ProductClassification> ProductClassification { get; set; }

        /// <summary>
        /// Represents the database set for the MedicationNotesTranslation entity.
        /// </summary>
        public DbSet<MedicationNotesTranslation> MedicationNotesTranslation { get; set; }

        /// <summary>
        /// Represents the database set for the WorkFlowConfigurationTransition entity.
        /// </summary>
        public DbSet<WorkFlowConfigurationTransition> WorkFlowConfigurationTransition { get; set; }

        /// <summary>
        /// Represents the database set for the ComorbidityDeviation entity.
        /// </summary>
        public DbSet<ComorbidityDeviation> ComorbidityDeviation { get; set; }

        /// <summary>
        /// Represents the database set for the ProductPackageItems entity.
        /// </summary>
        public DbSet<ProductPackageItems> ProductPackageItems { get; set; }

        /// <summary>
        /// Represents the database set for the TagsMaster entity.
        /// </summary>
        public DbSet<TagsMaster> TagsMaster { get; set; }

        /// <summary>
        /// Represents the database set for the VisitExaminationTemplateSection entity.
        /// </summary>
        public DbSet<VisitExaminationTemplateSection> VisitExaminationTemplateSection { get; set; }

        /// <summary>
        /// Represents the database set for the PackageLineSubGroupFeature entity.
        /// </summary>
        public DbSet<PackageLineSubGroupFeature> PackageLineSubGroupFeature { get; set; }

        /// <summary>
        /// Represents the database set for the VisitMode entity.
        /// </summary>
        public DbSet<VisitMode> VisitMode { get; set; }

        /// <summary>
        /// Represents the database set for the VisitVoiceTranscript entity.
        /// </summary>
        public DbSet<VisitVoiceTranscript> VisitVoiceTranscript { get; set; }

        /// <summary>
        /// Represents the database set for the TenantInvoiceLine entity.
        /// </summary>
        public DbSet<TenantInvoiceLine> TenantInvoiceLine { get; set; }

        /// <summary>
        /// Represents the database set for the GoodsReceiptSuggestion entity.
        /// </summary>
        public DbSet<GoodsReceiptSuggestion> GoodsReceiptSuggestion { get; set; }

        /// <summary>
        /// Represents the database set for the Counter entity.
        /// </summary>
        public DbSet<Counter> Counter { get; set; }

        /// <summary>
        /// Represents the database set for the Address entity.
        /// </summary>
        public DbSet<Address> Address { get; set; }

        /// <summary>
        /// Represents the database set for the BatchInterval entity.
        /// </summary>
        public DbSet<BatchInterval> BatchInterval { get; set; }

        /// <summary>
        /// Represents the database set for the StockAdjustmentWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<StockAdjustmentWorkflowActivityHistory> StockAdjustmentWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the LifeStyleChoiceTemplate entity.
        /// </summary>
        public DbSet<LifeStyleChoiceTemplate> LifeStyleChoiceTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the OpeningBalance entity.
        /// </summary>
        public DbSet<OpeningBalance> OpeningBalance { get; set; }

        /// <summary>
        /// Represents the database set for the Covid19HistoryChoice entity.
        /// </summary>
        public DbSet<Covid19HistoryChoice> Covid19HistoryChoice { get; set; }

        /// <summary>
        /// Represents the database set for the VisitExaminationTemplateSectionColumn entity.
        /// </summary>
        public DbSet<VisitExaminationTemplateSectionColumn> VisitExaminationTemplateSectionColumn { get; set; }

        /// <summary>
        /// Represents the database set for the VisitReferralNotes entity.
        /// </summary>
        public DbSet<VisitReferralNotes> VisitReferralNotes { get; set; }

        /// <summary>
        /// Represents the database set for the PackageLineSubGroupFeatureParameter entity.
        /// </summary>
        public DbSet<PackageLineSubGroupFeatureParameter> PackageLineSubGroupFeatureParameter { get; set; }

        /// <summary>
        /// Represents the database set for the PatientNotes entity.
        /// </summary>
        public DbSet<PatientNotes> PatientNotes { get; set; }

        /// <summary>
        /// Represents the database set for the DrugSystemOrganType entity.
        /// </summary>
        public DbSet<DrugSystemOrganType> DrugSystemOrganType { get; set; }

        /// <summary>
        /// Represents the database set for the UserCredentialLogin entity.
        /// </summary>
        public DbSet<UserCredentialLogin> UserCredentialLogin { get; set; }

        /// <summary>
        /// Represents the database set for the AppointmentService entity.
        /// </summary>
        public DbSet<Entities.AppointmentService> AppointmentService { get; set; }

        /// <summary>
        /// Represents the database set for the Occupation entity.
        /// </summary>
        public DbSet<Occupation> Occupation { get; set; }

        /// <summary>
        /// Represents the database set for the CalenderSettings entity.
        /// </summary>
        public DbSet<CalenderSettings> CalenderSettings { get; set; }

        /// <summary>
        /// Represents the database set for the InvestigationRecordResult entity.
        /// </summary>
        public DbSet<InvestigationRecordResult> InvestigationRecordResult { get; set; }

        /// <summary>
        /// Represents the database set for the TenantInvoiceFiles entity.
        /// </summary>
        public DbSet<TenantInvoiceFiles> TenantInvoiceFiles { get; set; }

        /// <summary>
        /// Represents the database set for the PatientComorbidityParameter entity.
        /// </summary>
        public DbSet<PatientComorbidityParameter> PatientComorbidityParameter { get; set; }

        /// <summary>
        /// Represents the database set for the Country entity.
        /// </summary>
        public DbSet<Country> Country { get; set; }

        /// <summary>
        /// Represents the database set for the WorkFlowConfigurationTransitionAuthorization entity.
        /// </summary>
        public DbSet<WorkFlowConfigurationTransitionAuthorization> WorkFlowConfigurationTransitionAuthorization { get; set; }

        /// <summary>
        /// Represents the database set for the EmrGeneralSettings entity.
        /// </summary>
        public DbSet<EmrGeneralSettings> EmrGeneralSettings { get; set; }

        /// <summary>
        /// Represents the database set for the EnrolledProgram entity.
        /// </summary>
        public DbSet<EnrolledProgram> EnrolledProgram { get; set; }

        /// <summary>
        /// Represents the database set for the PriceListVersionComponent entity.
        /// </summary>
        public DbSet<PriceListVersionComponent> PriceListVersionComponent { get; set; }

        /// <summary>
        /// Represents the database set for the InvoiceLine entity.
        /// </summary>
        public DbSet<InvoiceLine> InvoiceLine { get; set; }

        /// <summary>
        /// Represents the database set for the Credential entity.
        /// </summary>
        public DbSet<Credential> Credential { get; set; }

        /// <summary>
        /// Represents the database set for the UserRoster entity.
        /// </summary>
        public DbSet<UserRoster> UserRoster { get; set; }

        /// <summary>
        /// Represents the database set for the StockTransferWorkflowActivityHistory entity.
        /// </summary>
        public DbSet<StockTransferWorkflowActivityHistory> StockTransferWorkflowActivityHistory { get; set; }

        /// <summary>
        /// Represents the database set for the UOMConversion entity.
        /// </summary>
        public DbSet<UOMConversion> UOMConversion { get; set; }

        /// <summary>
        /// Represents the database set for the Timezone entity.
        /// </summary>
        public DbSet<Timezone> Timezone { get; set; }

        /// <summary>
        /// Represents the database set for the Currency entity.
        /// </summary>
        public DbSet<Currency> Currency { get; set; }

        /// <summary>
        /// Represents the database set for the CommunicationProviderSettings entity.
        /// </summary>
        public DbSet<CommunicationProviderSettings> CommunicationProviderSettings { get; set; }

        /// <summary>
        /// Represents the database set for the ProductTheraputicClassification entity.
        /// </summary>
        public DbSet<ProductTheraputicClassification> ProductTheraputicClassification { get; set; }

        /// <summary>
        /// Represents the database set for the TenantSubscriptionLineSubGroup entity.
        /// </summary>
        public DbSet<TenantSubscriptionLineSubGroup> TenantSubscriptionLineSubGroup { get; set; }

        /// <summary>
        /// Represents the database set for the VisitType entity.
        /// </summary>
        public DbSet<VisitType> VisitType { get; set; }

        /// <summary>
        /// Represents the database set for the PurchaseOrderLine entity.
        /// </summary>
        public DbSet<PurchaseOrderLine> PurchaseOrderLine { get; set; }

        /// <summary>
        /// Represents the database set for the Title entity.
        /// </summary>
        public DbSet<Title> Title { get; set; }

        /// <summary>
        /// Represents the database set for the DrugToDrugInteraction entity.
        /// </summary>
        public DbSet<DrugToDrugInteraction> DrugToDrugInteraction { get; set; }

        /// <summary>
        /// Represents the database set for the PrescriptionPrintTemplate entity.
        /// </summary>
        public DbSet<PrescriptionPrintTemplate> PrescriptionPrintTemplate { get; set; }

        /// <summary>
        /// Represents the database set for the VisitExaminationTemplateSectionGroupParameter entity.
        /// </summary>
        public DbSet<VisitExaminationTemplateSectionGroupParameter> VisitExaminationTemplateSectionGroupParameter { get; set; }

        /// <summary>
        /// Represents the database set for the Notification entity.
        /// </summary>
        public DbSet<Notification> Notification { get; set; }

        /// <summary>
        /// Represents the database set for the VisitMedication entity.
        /// </summary>
        public DbSet<VisitMedication> VisitMedication { get; set; }

        /// <summary>
        /// Represents the database set for the PackageSubscription entity.
        /// </summary>
        public DbSet<PackageSubscription> PackageSubscription { get; set; }
    }
}