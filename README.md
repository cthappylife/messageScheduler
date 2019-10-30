# MessageScheduler

MessageScheduler is an Azure Function App which sends SMS messages according to schedules in database.

It runs every day at 8am UTC time by default. The execution time is configurable.

Only the messages meeting all the below conditions will be sent:
- active
- scheduled to be sent today
- not yet sent today

## Twillio

MessageScheduler uses [Twilio](https://www.twilio.com) Azure Function binding to send SMS messages.

### Limitations

As MessageScheduler uses a trail Twilio account currently, it sends SMS messages only to the phone numbers pre-verified to Twilio, from a Twilio phone number. And the SMS messages starts with text "Sent from your Twilio trial account". It is possible to remove theses restrictions by upgrading the Twilio account.

## Storage

Scheduled messages are stored in an Azure Sql Database consist of the following tables:
- Receiver
- Schedule
- ScheduledMessages

## Schedules

MessageScheduler supports four types of schedules:
- DailySchedule: message should be sent once per day
- WeeklySchedule: message to be sent on some days of a week, e.g. every Monday, every Monday and Wednesday, every weekday, every weekend
- MonthlySchedule: message to be sent once per month, e.g. on every 5th day of a month
- CustomSchedule: message to be sent on a specific day, e.g. 1.11.2019.

## Configuration

Before running MessageScheduler, the following configurations need to be set in Function App's application settings:
- CheckScheduleTimer
- TwilioAccountSid
- TwilioAuthToken

## Execution

MessageScheduler Function App is triggered periodically according to the CheckScheduleTimer.
During the execution, it
- goes through schedules in database
- checks whether there are schedules meet aforementioned conditions
- send SMS messages if needed