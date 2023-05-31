import React from 'react';
import {tasks} from '../../util/dummyData';
import Task from './Task';

export default function TasksList() {

    return (
        <>
           { tasks.map(task => 
                 <Task task={task}></Task>
            )}
        </>
    );
}