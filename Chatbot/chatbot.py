#https://stackoverflow.com/questions/77505030/openai-api-error-you-tried-to-access-openai-chatcompletion-but-this-is-no-lon
#https://github.com/openai/openai-python?tab=readme-ov-file
#https://help.openai.com/en/articles/6891831-error-code-429-you-exceeded-your-current-quota-please-check-your-plan-and-billing-details

import os #operating system
from openai import OpenAI #OpenAi API

#get OpenAI API key for env variables
client = OpenAI(api_key = os.environ.get("OPENAI_API_KEY"))


#takes user input as prompt and uses gpt engine to generate response
def generate_response(prompt):
    response = client.chat.completions.create(
        model="gpt-3.5-turbo",
        messages=[{"role": "user", "content": prompt}]
    )
    return response.choices[0].message.content.strip()


#main function where the conversation will happen
def main():
    print("Welcome to the chat!")
    print("Type 'bye' to end the conversation")

    while True:
        #get user input
        user_input = input("You: ")

        #check if user has said 'bye'
        if user_input.lower() == "bye":
            print("Chatbot: See ya!")
            break

        #get gpt response from input
        response = generate_response(user_input)
        print("Chatbot:", response)

if __name__ == "__main__":
    main()