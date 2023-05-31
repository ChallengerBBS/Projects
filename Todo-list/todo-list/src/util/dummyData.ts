import { Task, TaskStatus } from '../types/types';

export const tasks: Task[] = [
  {
    title: "Take the dog out",
    description: "Take the dog out for it's daily routine.",
    createdOn: new Date("2023-05-31T08:30"),
    toBeCompletedOn: new Date("2023-05-31T10:30"),
    priority: 3,
    status: TaskStatus.Completed,
},
{
    title: "Schedule a meeting with the indy",
    description: "The BMW has to be fixed, so call the indy to arrange a meeting.",
    createdOn: new Date("2023-31-05"),
    priority: 2,
    status: TaskStatus.Pending
},
{
  title: "Brush your teeth",
  createdOn: new Date("2023-31-05"),
  priority: 1,
  status: TaskStatus.Canceled
},
];