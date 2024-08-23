# social-network-console

# Social Network

Implement a console-based social networking application that satisfies the scenarios listed below. The application must use the console for input and output.

Users submit commands to the application. Commands always start with the user’s name.

Do not worry about handling any exceptions or invalid commands. Assume the user will always type the correct command.

Do not make it work over a network or across processes, do it all in memory assuming users are on the same terminal.

Non-existing users should be created as they post their first message. The application should not start with a predefined list of users.

## <u>Scenarios</u>

<u>Posting</u>

Alice can publish messages to a personal timeline.
```bash
~ % Alice /post What a wonderfully sunny day!
```

<u>Reading</u>

Bob can view Alice’s timeline
```bash
~ % Bob /timeline Alice
```

<u>Following</u>

Charlie can subscribe to Alice’s timeline and view an aggregate list of all subscriptions
```bash
~ % Charlie /follow Alice
```

<u>Wall</u>

Charlie can view an aggregate list of all the people he has subscribed to follow.
```bash
~ % Charlie /wall
```

Note: If Charlie follows Alice and Bob he will see a time sequenced list of post from both of them on his wall. That is to say the post are displayed with the most recent at the top.

## Bonus 🌟

<u>Mentions</u>

Bob can link to Charlie in a message using ‘@’.
```bash
~ % Bob /post @Charlie what are your plans tonight?
```

Note: this is not a new command, just an expansion of how the /post command works. Any mentions should appear on a user’s wall even if they do not follow the user.

<u>Direct Messages</u>

Mallory can send a private message to Alice.
```bash
~ % Mallory /send_message Alice
```

Alice can view all private messages
```bash
~ % Alice /view_messages
```