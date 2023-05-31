export interface Task{
    title: string,
    description?: string,
    createdOn: Date,
    toBeCompletedOn?: Date,
    priority: number,
    status: TaskStatus
}

export enum TaskStatus {
    Completed = 'Completed',
    Pending = "Pending",
    Canceled = "Canceled",
}

export interface User{
    username: string,
    password: string,
    email: string,
    role: UserRoles,
}

export enum UserRoles {
    User = 'User',
    Admin = 'Admin',
    Moderator = 'Moderator'
}


