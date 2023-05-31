import { TasksProps } from './Tasks.definitions';
import styles from './task.module.css';

export default function Task(props: TasksProps) {

    return (
        <>
            <div className={styles.task}>
                {props.task.title}
            </div>
        </>
    );
}