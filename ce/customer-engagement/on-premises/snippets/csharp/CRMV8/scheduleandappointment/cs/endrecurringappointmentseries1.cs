// <snippetendrecurringappointmentseries1>



 // Retrieve a recurring appointment series
 RecurringAppointmentMaster retrievedRecurringAppointmentSeries = (RecurringAppointmentMaster)_serviceProxy.Retrieve(RecurringAppointmentMaster.EntityLogicalName, _recurringAppointmentMasterId, new ColumnSet(true));

 // Use the DeleteOpenInstances message to end the series to the
 // last occurring past instance date w.r.t. the series end date
 // (i.e., 20 days from today). Effectively, that means that the 
 // series will end after the third instance (day 14) as this
 // instance is the last occuring past instance w.r.t the specified 
 // series end date (20 days from today).
 // Also specify that the state of past instances (w.r.t. the series 
 // end date) be set to 'completed'.
 DeleteOpenInstancesRequest endAppointmentSeries = new DeleteOpenInstancesRequest
 {
     Target = retrievedRecurringAppointmentSeries,
     SeriesEndDate = DateTime.Today.AddDays(20),
     StateOfPastInstances = (int)AppointmentState.Completed
 };
 _serviceProxy.Execute(endAppointmentSeries);

 Console.WriteLine("The recurring appointment series has been ended after the third occurrence.");

// </snippetendrecurringappointmentseries1>