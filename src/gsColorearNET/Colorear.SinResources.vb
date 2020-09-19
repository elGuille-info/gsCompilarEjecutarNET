﻿'------------------------------------------------------------------------------
' Clase definida en la biblioteca para .NET Standard 2.0            (10/Sep/20)
' Basada en gsColorear y gsColorearCore
'
' v1.0.0.10 18/Sep/20   Añado init, record y with a las palabras clave de C#
'           19/Sep/20   Añado when (de C# 8.0)
'

Option Strict On
Option Infer On

Partial Public Class Colorear

#Region " Las palabras clave asignadas a constantes "

    ' Declaradas como constantes públicas
    Private Const CSKeywords As String = "abstract
add
as
ascending
base
bool
break
by
byte
case
catch
char
checked
class
const
continue
decimal
default
define
delegate
descending
do
double
elif
else
endif
endregion
enum
error
event
explicit
extern
false
finally
fixed
float
for
foreach
from
get
goto
group
if
implicit
in
init
int
into
interface
internal
is
join
let
line
lock
long
namespace
new
null
object
operator
orderby
out
override
params
partial
private
protected
public
readonly
record
ref
region
remove
return
sbyte
sealed
select
set
short
sizeof
stackalloc
static
string
struct
switch
this
throw
true
try
typeof
uint
ulong
unchecked
undef
unsafe
ushort
using
value
var
virtual
void
volatile
warning
when
where
while
with
yield
"
    Private Const VBKeywords As String = "AddHandler
AddressOf
Aggregate
Alias
And
AndAlso
Ansi
As
Assembly
Auto
Binary
Boolean
By
ByRef
Byte
ByVal
Call
Case
Catch
CBool
CByte
CChar
CDate
CDbl
CDec
Char
CInt
Class
CLng
CObj
Compare
Const
Continue
CSByte
CShort
CSng
CStr
CType
CUInt
CULng
CUShort
Custom
Date
Decimal
Declare
Default
Delegate
Dim
DirectCast
Distinct
Do
Double
Each
Else
ElseIf
End
EndIf
Enum
Erase
Error
Event
Exit
Expands
Explicit
Extends
ExternalSource
ExternalSource
False
Finally
For
Friend
From
Function
Get
GetType
Global
GoTo
Group
Handles
If
Implements
Imports
In
Infer
Inherits
Integer
Interface
Is
IsFalse
IsNot
IsTrue
Join
Let
Lib
Like
Long
Loop
Me
Mod
Module
MustInherit
MustOverride
My
MyBase
MyClass
Namespace
Narrowing
New
Next
Not
Nothing
NotInheritable
NotOverridable
Object
Of
Off
On
Operator
Option
Optional
Or
Order
OrElse
Overloads
Overridable
Overrides
ParamArray
Partial
Preserve
Private
Property
Protected
Public
RaiseEvent
ReadOnly
ReDim
Region
REM
RemoveHandler
Resume
Return
SByte
Select
Set
Shadows
Shared
Short
Single
Skip
Static
Step
Stop
Strict
String
Structure
Sub
SyncLock
Take
Then
Throw
To
True
Try
TryCast
TypeOf
UInteger
ULong
Unicode
Until
UShort
Using
When
Where
While
Widening
With
WithEvents
WriteOnly
Xor
"
    Private Const VB6Keywords As String = "AddressOf
And
Any
As
Attribute
Base
BEGIN
Binary
Boolean
ByRef
Byte
ByVal
Call
Case
CLASS
Close
Compare
Const
Currency
DataBindingBehavior
DataSourceBehavior
Date
Decimal
Declare
DefBool
DefByte
DefCur
DefDate
DefDbl
DefDec
DefInt
DefLng
DefObj
DefSng
DefStr
DefVar
Dim
Do
Double
Each
Else
ElseIf
Empty
End
Enum
Eqv
Erase
Error
Event
Exit
Explicit
False
For
Friend
Function
Get
Global
GoSub
GoTo
If
Imp
Implements
Input
Integer
Is
Len
Let
Like
Line
Load
Lock
Long
Loop
LSet
Me
Mid
Mod
MTSTransactionMode
MultiUse
New
Next
Not
Nothing
Null
Object
On
Open
Option
Optional
Or
ParamArray
Persistable
Preserve
Print
Private
Property
Public
Put
RaiseEvent
Randomize
ReDim
Rem
Reset
Resume
Return
RSet
Seek
Select
Set
Single
Static
Step
Stop
String
Sub
Then
Time
To
True
Type
Unload
Unlock
Until
Variant
VB_Creatable
VB_Description
VB_Exposed
VB_GlobalNameSpace
VB_HelpId
VB_MemberFlags
VB_Name
VB_PredeclaredId
VB_UserMemId
VERSION
Wend
While
Width
Win16
Win32
With
WithEvents
Write
Xor
"
    Private Const DotNetKeywords As String = "abstract
add
addhandler
addressof
aggregate
alias
and
andalso
ansi
as
ascending
assembly
auto
base
bool
boolean
break
by
byref
byte
byval
call
case
catch
cbool
cbyte
cchar
cdate
cdbl
cdec
char
checked
cint
class
clng
cobj
const
const
continue
csbyte
cshort
csng
cstr
ctype
cuint
culng
cushort
custom
date
decimal
declare
default
define
delegate
descending
dim
directcast
distinct
do
double
each
elif
else
elseif
end
endif
endregion
enum
erase
error
error
event
exit
expands
explicit
extends
extern
externalsource
false
finally
fixed
float
for
foreach
friend
from
function
get
gettype
global
goto
group
groupby
handles
if
implements
implicit
imports
in
infer
inherits
int
integer
interface
internal
into
is
isfalse
isnot
istrue
join
let
lib
like
line
lock
long
loop
me
mod
module
mustinherit
mustoverride
my
mybase
myclass
namespace
narrowing
new
next
not
nothing
notinheritable
notoverridable
null
object
of
off
on
operator
option
optional
or
order
orderby
orelse
out
overloads
overridable
override
overrides
paramarray
params
partial
preserve
private
property
protected
public
raiseevent
readonly
redim
ref
region
rem
remove
removehandler
resume
return
sbyte
sealed
select
set
shadows
shared
short
single
sizeof
skip
stackalloc
static
step
stop
strict
string
struct
structure
sub
switch
synclock
take
then
this
throw
to
true
try
trycast
typeof
uint
uinteger
ulong
unchecked
undef
unicode
unsafe
until
ushort
using
value
var
virtual
void
volatile
warning
when
where
while
widening
with
withevents
writeonly
xor
yield
"
    Private Const JavaKeywords As String = "abstract
assert
boolean
break
byte
case
catch
char
class
const
continue
default
do
double
else
enum
extends
false
final
finally
float
for
goto
if
implements
import
instanceof
int
interface
long
native
new
null
package
private
protected
public
return
short
static
strictfp
super
switch
synchronized
this
throw
throws
transient 
true
try
void
volatile
while
"
    Private Const FSharpKeywords As String = "abstract
and
as
asr
assert
async
atomic
base
begin
bigint
bignum
bool
break
byte
bytechar
bytestring
checked
class
component
const
constraint
constraint
constructor
continue
continue
decimal
default
delegate
do
done
downcast
downto
eager
else
end
enum
event
exception
exn
explicit
external
false
finally
fixed
float
float32
float64
for
fun
function
functor
ieee32
ieee64
if
implicit
in
include
inherit
inline
int
int16
int32
int64
int8
interface
land
lazy
let
lor
lsl
lsr
lxor
match
member
method
mixin
mod
module
mutable
namespace
nativeint
new
null
obj
object
of
open
operator
or
override
process
property
protected
protected
public
pure
readonly
rec
return
sbyte
sealed
sig
static
string
struct
switch
then
this
to
true
try
type
uint16
uint32
uint64
uint8
unativeint
upcast
val
virtual
void
volatile
when
while
with
xint
"
    Private Const SQLKeywords As String = "ABSOLUTE
ADD
ALTER
ARITHABORT
ARITHIGNORE
AS
ASC
AT
AUTHORIZATION
BEGIN
BLOCKSIZE
BREAK
BROWSE
BY
CASCADE
CHAR
CHECK
CHECKALLOC
CHECKCATALOG
CHECKDB
CHECKPOINT
CHECKTABLE
CLOSE
CLUSTERED
columns
COMMIT
COMPUTE
CONCAT
CONNECT
CONSTRAINT
CONTINUE
CREATE
CURRENT
CURSOR
DATABASE
DATEFORMAT
DBCC
DBREPAIR
DEALLOCATE
DECLARE
DEFAULT
DELAY
DELETE
DESC
DISK
DISTINCT
DROP
DROP_EXISTING
DUMP
ELSE
END
ESCAPE
EXEC
EXECUTE
FAST
FETCH
FILE
FILLFACTOR
FIRST
FOR
FOREIGN
FROM
FULL
FUNCTION
GO
GOTO
GRANT
GROUP
HASH
HAVING
HEADERONLY
HOLDLOCK
IDENTITY_INSERT
IF
IGNORE_DUP_KEY
INDEX
INIT
INNER
INSERT
INTO
IO
IS
ISOLATION
KEY
KILL
LAST
LEVEL
LOAD
LOOP
MAX
MERGE
MIN
MIRROR
MIRROREXIT
NAME
NEXT
NO_LOG
NOCOUNT
NOEXEC
NOINIT
NONCLUSTERED
NOUNLOAD
NOWAIT
OF
OFF
OFFSETS
ON
ONLY
OPEN
OPTION
ORDER
OUTPUT
OVERRIDE
PARSEONLY
PERCENT
PHYSNAME
PREPARE
PRIMARY
PRINT
PRIOR
PRIVILEGES
PROC
PROCEDURE
PROCESSEXIT
PUBLIC
QUOTED_IDENTIFIER
READ
READTEXT
RECOMPILE
RECONFIGURE
REFERENCES
RELATIVE
REM
REMIRROR
REMOVE
RETAINDAYS
RETURN
RETURNS
REVOKE
ROLLBACK
ROWS
RULE
SAVE
SCHEMA
SELECT
SERIALIZABLE
SET
SETUSER
SHOWPLAN
SHUTDOWN
SIZE
SORTED_DATA
STATISTICS
STRIPE
TABLE
THEN
TIME
TO
TOP
TRACEOFF
TRACEON
TRAN
TRANSACTION
TRUNCATE
TRUNCATE_ONLY
TRIGGER
TSEQUAL
UNION
UNIQUE
UNLOAD
UNMIRROR
UPDATE
USE
VALUES
VDEVNO
VIEW
VSTART
WAITFOR
WHEN
WHERE
WHILE
WITH
WORK
WRITETEXT
ALL
AND
ANY
BETWEEN
EXISTS
IN
JOIN
LIKE
NOT
NULL
OR
OUTER
SOME
ABS
ACOS
ASCII
ASIN
ATAN
ATN2
AVG
CASE
CAST
CEILING
CHARINDEX
COALESCE
COL_LENGTH
COL_NAME
CONVERT
COS
COT
COUNT
DATALENGTH
DATEADD
DATEDIFF
DATENAME
DATEPART
DAY
DB_ID
DEGREES
EXP
FLOOR
GETDATE
GETUTCDATE
HOST_ID
HOST_NAME
INDEX_COL
INDEXPROPERTY
ISNULL
LEFT
LOG
LOG10
LOWER
LTRIM
MONTH
NULLIF
OBJECT_ID
OBJECT_NAME
OBJECTPROPERTY
OPENXML
PATINDEX
PI
POWER
RADIANS
RAND
REPLACE
REPLICATE
REVERSE
RIGHT
ROUND
RTRIM
SIGN
SIN
SOUNDEX
SPACE
SQRT
STR
STUFF
SUBSTRING
SUM
SUSER_ID
SUSER_NAME
TAN
TEXTPTR
TEXTVALID
UPPER
USER
USER_ID
USER_NAME
YEAR
XML
bigint
binary
bit
char
cursor
datetime
decimal
double
float
image
int
money
nchar
numeric
nvarchar
real
smalldatetime
smallint
smallmoney
sql_variant
table
text
timestamp
tinyint
varbinary
varchar
uniqueidentifier
xml
varying
character
Dec
precision
integer
national
rowversion
"
    Private Const CPPKeywords As String = "define
elif
else
endif
error
if
ifdef
ifndef
include
pragma
undef
defined
__asm
__based
__cdecl
__cplusplus
__emit
__export
__far
__fastcall
__fortran
__huge
__inline
__interrupt
__loadds
__near
__pascal
__saveregs
__segment
__segname
__self
__stdcall
__syscall
argc
argv
auto
break
case
char
const
continue
default
do
double
else
enum
envp
extern
float
for
goto
if
int
long
main
register
return
short
signed
sizeof
static
struct
switch
typedef
union
unsigned
void
volatile
wchar_t
while
wmain
__multiple_inheritance
__single_inheritance
__virtual_inheritance
bool
catch
class
const_cast
delete
dynamic_cast
explicit
false
friend
inline
mutable
namespace
new
operator
private
protected
public
reinterpret_cast
static_cast
template
this
throw
true
try
typeid
typename
using
virtual
"
    Private Const PascalKeywords As String = "absolute
abstract
alias
and
array
as
asm
assembler
begin
break
case
cdecl
class
const
constructor
continue
default
destructor
dispose
div
do
downto
else
end
ensures
event
except
exit
export
exports
external
false
far
fault
file
finalization
finally 
for
forward
function
goto
if
implementation
in
index
inherited
initialization
inline
interface
invariant
is
iterator
label
library
loop
method
mod
name
namespace
near
new
nil
not
object
of
old
on
operator
or
out
override
packed
pascal
popstack
private
procedure
program
property
protected
public
published
raise
read
readonly
record
register
repeat
requires
saveregisters
sealed
self
set
shl
shr
static
stdcall
string
then
to
true
try
type
unit
until
uses
using
var
virtual
while
with
write
xor
"
    Private Const ILKeywords As String = "abstract
add
addon
algorithm
alignment
and
ansi
any
arglist
array
as
assembly
assert
at
auto
autochar
beforefieldinit
beq
bge
bgt
ble
blob
blob_object
blt
bne
bool
box
br
break
brfalse
brfalsebrnullbrzero
brtrue
brtruebrinst
bstr
bytearray
byvalstr
call
calli
callvirt
carray
castclass
catch
cctor
cdecl
ceq
cf
cgt
char
cil
ckfinite
class
clsid
clt
conv
corflags
cpblk
cpobj
ctor
currency
custom
data
date
decimal
default
demand
deny
div
dup
emitbyte
endfilter
endfinallyendfault
entrypoint
error
event
explicit
export
extends
extern
famandassem
family
famorassem
fastcall
fault
field
file
filetime
filter
final
finally
fire
fixed
Float
float32
float64
forwardref
fromunmanaged
get
handler
hash
hidebysig
hresult
i1
i2
i4
i8
i8ldelem
i8ldind
idispatch
imagebase
in
inheritcheck
init
initblk
initobj
initonly
instance
int
int16
int32
int64
int8
interface
internalcall
isinst
iunknown
jmp
lasterr
ldarg
ldarga
ldc
ldc.i4
ldelem
ldelema
ldfld
ldflda
ldftn
ldind
ldlen
ldloc
ldloca
ldnull
ldobj
ldsfld
ldsflda
ldstr
ldtoken
ldvirtftn
leave
linkcheck
literal
locale
localloc
locals
lpstr
lpstruct
lptstr
lpwstr
M1
m1ldc
managed
marshal
maxstack
method
mkrefany
module
mresource
mul
namespace
native
neg
nested
newarr
newobj
newslot
noappdomain
noinlining
nomachine
nomangle
nometadata
noncasdemand
noncasinheritance
noncaslinkdemand
nop
noprocess
not
notserialized
null
nullref
object
objectref
opt
optil
or
other
out
override
ovf
param
permission
permissionset
permitonly
pinvokeimpl
pop
prejitdeny
prejitgrant
preservesig
private
privatescope
public
publickey
publickeytoken
r4
r8
record
ref
refanytype
refanyval
rem
removeon
reqmin
reqopt
reqrefuse
reqsecobj
request
ret
rethrow
rtspecialname
runtime
safearray
sbrinst
sbrnull
sbrzero
set
shl
shr
size
sizeof
specialname
starg
static
stdcall
stelem
stfld
stind
stloc
stobj
storage
stored_object
stream
streamed_object
string
struct
stsfld
sub
subsystem
switch
synchronized
syschar
sysstring
tail
tbstr
thiscall
throw
to
try
typedref
u1
u2
u4
u8
uint32
uint8
un
unaligned
unbox
unicode
unmanaged
unmanagedexp
unsigned
userdefined
value
valuetype
vararg
variant
vector
ver
virtual
void
volatile
vtentry
vtfixup
xor
zeroinit
"

    ''' <summary>
    ''' Diccionario con las palabras clave de cada lenguaje soportado.
    ''' El lenguaje se usará desde la enumeración Lenguajes.
    ''' palabras = LangsKeywords(Lenguajes.CS.ToString).
    ''' </summary>
    ''' <remarks>11/Sep/2020</remarks>
    Private Shared LangsKeywords As New Dictionary(Of String, String) From {
        {Lenguajes.CS.ToString, CSKeywords}, {Lenguajes.VB.ToString, VBKeywords},
        {Lenguajes.VB6.ToString, VB6Keywords}, {Lenguajes.dotNet.ToString, DotNetKeywords},
        {Lenguajes.Java.ToString, JavaKeywords}, {Lenguajes.FSharp.ToString, FSharpKeywords},
        {Lenguajes.SQL.ToString, SQLKeywords}, {Lenguajes.CPP.ToString, CPPKeywords},
        {Lenguajes.Pascal.ToString, PascalKeywords}, {Lenguajes.IL.ToString, ILKeywords}}

#End Region

    ''' <summary>
    ''' Recupera un array con las palabras del lenguaje indicado.
    ''' </summary>
    ''' <param name="le">Un valor de Lenguajes</param>
    Public Shared Function LangKeyWords(le As Lenguajes) As String()

        Dim palabras() As String = Nothing

        Select Case le
            Case Lenguajes.Ninguno, Lenguajes.XML
                Return palabras
            Case Else
                Return LangsKeywords(le.ToString).Split(vbCrLf.ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        End Select

    End Function

End Class
