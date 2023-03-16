import { createContext, useContext, useState, useEffect, ReactNode } from 'react'
import { api } from '../services/api'

type Transaction = {
  id: string;
  title: string;
  type: string;
  category: string;
  amount: number;
  createdAt: string;
}

type NewTransaction = Omit<Transaction, 'id' | 'createdAt'>

/*
type NewTransaction = {
  title: string;
  type: string;
  category: string;
  amount: number;
}
*/

type TransactionsProviderProps = {
  children: ReactNode;
}

type TransactionsContextData = {
  transactions: Transaction[];
  createTransaction: (transaction: NewTransaction) => Promise<void>;
}

const TransactionsContext = 
  createContext<TransactionsContextData>({} as TransactionsContextData)

export function TransactionsProvider({ children }: TransactionsProviderProps) {
  const [transactions, setTransactions] = useState<Transaction[]>([])

  useEffect(() => {
    api.get('transactions')
      .then(response => {
        setTransactions(response.data)
      })
  }, [])

  async function createTransaction(newTransaction: NewTransaction) {    

    const response = await api.post('/transactions', {
      ...newTransaction
    });
    
    if (response.status == 200) {
      const transaction: Transaction = {
        id: '',
        title: newTransaction.title,
        amount: newTransaction.amount,
        category: newTransaction.category,
        type: newTransaction.type,
        createdAt: new Date().toString()

      };

      setTransactions([...transactions, transaction])
    }
  }

  return (
    <TransactionsContext.Provider value={{ transactions, createTransaction }}>
      {children}
    </TransactionsContext.Provider>
  )
}  

export function useTransactions() {
  const context = useContext(TransactionsContext)

  return context
}
