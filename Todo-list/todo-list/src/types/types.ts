interface Task{
    title: string,
    description: string,
    createdOn: Date,
    toBeCompletedOn: Date,
    priority: number,
    status: "completed" | "pending" | "canceled",
}

interface User{
    username: string,
    password: string,
    email: string,
    role: "user" | "admin" | "moderator",
}


