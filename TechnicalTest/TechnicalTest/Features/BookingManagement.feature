Feature: Booking Management
	In order to run my hotel business
	As a hotel manager
	I want to create and delete bookings

@bookings @sanity
Scenario: Create a booking
	Given the user is on hotel bookings page
	When  the user creates a new booking
	Then the booking is added to the list of bookings


@bookings @sanity
Scenario: Delete a booking
	Given the user is on hotel bookings page
	And there are one or more bookings
	When the user deletes the first booking
	Then The number of bookings is reduced by 1
