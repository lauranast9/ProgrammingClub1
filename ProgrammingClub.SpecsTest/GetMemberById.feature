Feature: Retrieve Member by ID

Scenario: Existing Member
	Given a member exists with IdMember "68853d12-02e6-4de7-8123-0309a87b1010"
	When the member is requested by IdMember
	Then the response should contain the member with the same IdMember