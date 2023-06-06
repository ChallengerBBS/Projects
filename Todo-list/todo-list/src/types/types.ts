export interface Task {
  id: number;
  title: string;
  createdOn: Date;
  priority: number;
  status: TaskStatus;
  description?: string;
  toBeCompletedOn?: Date;
}

export enum TaskStatus {
  Completed = "Completed",
  Pending = "Pending",
  Canceled = "Canceled",
}

export class Task implements Task {
  constructor(
    id: number = 1,
    title: string = "Default task title",
    status: TaskStatus = TaskStatus.Pending,
    priority: number = 1,
    description: string = "Default task description",
    toBeCompletedOn?: Date
  ) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.createdOn = new Date();
    this.toBeCompletedOn = toBeCompletedOn;
    this.priority = priority;
    this.status = status;
  }
}

export interface User {
  username: string;
  password: string;
  email: string;
  role: UserRoles;
}

export enum UserRoles {
  User = "User",
  Admin = "Admin",
  Moderator = "Moderator",
}
