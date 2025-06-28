Feature: Retrive Member By ID

Scenario: Existing Member
Given a member exists with IdMember "ad427d48-828a-4e48-a707-61e2c8a8e17f"
When the member is requested by IdMember
Then the member response should contain the member with the same IdMember